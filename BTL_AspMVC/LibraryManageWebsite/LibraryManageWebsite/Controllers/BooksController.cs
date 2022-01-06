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
            ViewBag.BookId = BaseDAO.RandomString(10);
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OwnerId,Name,Author,Publisher,Price,Quantity,Year,Views,Status")] Book book)
        {
            if (ModelState.IsValid)
            {
                await bookDAO.Add(book);

                TempData["AlertSuccessMessage"] = "Thêm sách mới thành công!";

                return RedirectToAction("Index");
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
                await bookDAO.Update(book);

                TempData["AlertSuccessMessage"] = "Cập nhật thông tin thành công!";

                return RedirectToAction("Index");
            }
            
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<ActionResult> Delete(string id)
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

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await bookDAO.Delete(id);

            TempData["AlertSuccessMessage"] = "Xóa sách thành công!";

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
