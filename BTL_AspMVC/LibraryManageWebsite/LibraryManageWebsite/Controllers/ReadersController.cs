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
    public class ReadersController : Controller
    {
        private ReaderDAO readerDAO = new ReaderDAO();

        // GET: Readers
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var readerList = await readerDAO.GetByPaged(page, pageSize, keyword);

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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = await readerDAO.GetById(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // GET: Readers/Create
        public ActionResult Create()
        {
            ViewBag.ReaderId = BaseDAO.RandomString(10);
            return View();
        }

        // POST: Readers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OwnerId,Name,Gender,Birthday,Email,Phone,Address,Status")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                var checkOwnerId = await readerDAO.CheckOwnerId(reader.OwnerId);

                if (checkOwnerId)
                {
                    await readerDAO.Add(reader);

                    TempData["AlertSuccessMessage"] = "Thêm đọc giả mới thành công!";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["AlertErrorMessage"] = "Mã xác minh không hợp lệ";
                }
            }

            return View(reader);
        }

        // GET: Readers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = await readerDAO.GetById(id);
            if (reader == null)
            {
                return HttpNotFound();
            }

            return View(reader);
        }

        // POST: Readers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OwnerId,Name,Gender,Birthday,Email,Phone,Address,Status")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                await readerDAO.Update(reader);

                TempData["AlertSuccessMessage"] = "Cập nhật thông tin thành công!";

                return RedirectToAction("Index");
            }

            return View(reader);
        }

        // GET: Readers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = await readerDAO.GetById(id);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // POST: Readers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await readerDAO.Delete(id);

            TempData["AlertSuccessMessage"] = "Xóa đọc giả thành công!";

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
