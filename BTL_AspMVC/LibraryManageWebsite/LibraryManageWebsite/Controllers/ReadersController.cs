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
    public class ReadersController : Controller
    {
        private ReaderDAO readerDAO = new ReaderDAO();

        string readerId = BaseDAO.RandomString(10);

        // GET: Readers
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var ownerId = (string)Session["ownerId"];

            var readerList = await readerDAO.GetByPaged(page, pageSize, keyword, ownerId);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(readerList);
        }

        // GET: Readers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Reader reader = await readerDAO.GetById(id);

            if (reader == null || Session["ownerId"] == null || (string)Session["ownerId"] != reader.OwnerId)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(reader);
        }

        // GET: Readers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Readers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OwnerId,Name,Gender,Birthday,Email,Phone,Address,Status")] Reader reader)
        {
            reader.Id = readerId;

            if (ModelState.IsValid)
            {
                if (readerDAO.CheckEmail(reader.Email, (string)Session["ownerId"]) == false)
                {
                    TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại email!";
                }
                else if (readerDAO.CheckPhone(reader.Phone, (string)Session["ownerId"]) == false)
                {
                    TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại số điện thoại!";
                }
                else
                {
                    if (await readerDAO.Add(reader))
                    {
                        TempData["AlertSuccessMessage"] = "Thêm đọc giả mới thành công!";

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["AlertErrorMessage"] = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                        return View(reader);
                    }
                }
            }

            return View(reader);
        }

        // GET: Readers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Reader reader = await readerDAO.GetById(id);

            if (reader == null || Session["ownerId"] == null || (string)Session["ownerId"] != reader.OwnerId)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(reader);
        }

        // POST: Readers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OwnerId,Name,Gender,Birthday,Email,Phone,Address,Status")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                var getReaderFromDB = await readerDAO.GetById(reader.Id);

                if (getReaderFromDB.Email != reader.Email)
                {
                    if (readerDAO.CheckEmail(reader.Email, (string)Session["ownerId"]) == false)
                    {
                        TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại email!";

                        return View(reader);
                    }
                }
                else if (getReaderFromDB.Phone != reader.Phone)
                {
                    if (readerDAO.CheckPhone(reader.Phone, (string)Session["ownerId"]) == false)
                    {
                        TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại số điện thoại!";

                        return View(reader);
                    }
                }

                if (await readerDAO.Update(reader))
                {
                    TempData["AlertSuccessMessage"] = "Cập nhật thông tin thành công!";

                    return RedirectToAction("Details", "Readers", new { id = reader.Id });
                }
                else
                {
                    TempData["AlertErrorMessage"] = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                    return View(reader);
                }
            }

            return View(reader);
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
