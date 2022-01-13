using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryManageWebsite.Models.DAO;
using LibraryManageWebsite.Models.EF;

namespace LibraryManageWebsite.Controllers
{
    [Authorize(Roles = "Admin, Nhân viên")]
    public class BooksController : Controller
    {
        private BookDAO bookDAO = new BookDAO();

        string bookId = BaseDAO.RandomString(10);

        // GET: Books
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var ownerId = (string)Session["ownerId"];

            var getBookList = await bookDAO.GetByPaged(page, pageSize, keyword, ownerId);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(getBookList);
        }

        // GET: Books/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Book book = await bookDAO.GetById(id);

            if (book == null || Session["ownerId"] == null || book.OwnerId != (string )Session["ownerId"])
            {
                return RedirectToAction("Error", "Home");
            }

            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OwnerId,Name,Author,Publisher,Price,Quantity,Year,Views,Status")] Book book)
        {
            book.Id = bookId;

            if (ModelState.IsValid)
            {
                if (bookDAO.IsExited(book.Name, book.Author, (string)Session["ownerId"]))
                {
                    if (await bookDAO.Add(book))
                    {
                        TempData["AlertSuccessMessage"] = "Thêm sách mới thành công!";

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["AlertErrorMessage"] = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                        return View(book);
                    }
                }
                else
                {
                    TempData["AlertErrorMessage"] = "Sách này đã có trong thư viện. Vui lòng kiểm tra lại!";

                    return View(book);
                }
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Book book = await bookDAO.GetById(id);

            if (book == null || Session["ownerId"] == null || book.OwnerId != (string)Session["ownerId"])
            {
                return RedirectToAction("Error", "Home");
            }
            
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OwnerId,Name,Author,Publisher,Price,Quantity,Year,Views,Status")] Book book)
        {
            if (ModelState.IsValid)
            {
                var getBookFromDB = await bookDAO.GetById(book.Id);

                if (getBookFromDB.Name != book.Name)
                {
                    if (!bookDAO.IsExited(book.Name, book.Author, (string)Session["ownerId"]))
                    {
                        TempData["AlertErrorMessage"] = "Sách này đã có trong thư viện. Vui lòng kiểm tra lại!";

                        return View(book);
                    }
                }
                else if (getBookFromDB.Author != book.Author)
                {
                    if (!bookDAO.IsExited(book.Name, book.Author, (string)Session["ownerId"]))
                    {
                        TempData["AlertErrorMessage"] = "Sách này đã có trong thư viện. Vui lòng kiểm tra lại!";

                        return View(book);
                    }
                }

                if (await bookDAO.Update(book))
                {
                    TempData["AlertSuccessMessage"] = "Cập nhật thông tin thành công!";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["AlertErrorMessage"] = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                    return View(book);
                }
            }
            
            return View(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public async Task<JsonResult> GetBookListForPromissoryNote(string bookName)
        {
            // bỏ dấu [] ở định dạng kiểu mảng của tham số json
            //json = json.Replace("[", "").Replace("]", "");

            // tạo mảng với các phần tử là tên sách trong thư viện
            //string[] bookNameArr = json == string.Empty ? new string[0] : json.Split(',').Select(t => t).ToArray();

            var model = await bookDAO.GetBookListByName(bookName, (string)Session["ownerId"]);

            return Json(new
            {
                data = model.Select(t => new
                {
                    Id = t.Id,
                    Name = t.Name,
                    Author = t.Author,
                    Publisher = t.Publisher
                }).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
