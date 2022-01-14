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
using Newtonsoft.Json;

namespace LibraryManageWebsite.Controllers
{
    [Authorize(Roles = "Admin, Nhân viên")]
    public class PromissoryNotesController : Controller
    {
        private PromissoryNoteDAO pnDAO = new PromissoryNoteDAO();

        string pnId = BaseDAO.RandomString(10);

        // GET: PromissoryNotes
        public ActionResult Index()
        {
            //var promissoryNotes = db.PromissoryNotes.Include(p => p.Owner).Include(p => p.Reader).Include(p => p.User);
            return View(/*promissoryNotes.ToList()*/);
        }

        // GET: PromissoryNotes/Details/5
        public ActionResult Details(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //PromissoryNote promissoryNote = db.PromissoryNotes.Find(id);
            //if (promissoryNote == null)
            //{
            //    return HttpNotFound();
            //}
            return View(/*promissoryNote*/);
        }

        // GET: PromissoryNotes/Create
        public async Task<ActionResult> Create()
        {
            var ownerId = (string)(Session["ownerId"]);

            ViewBag.GetReaderList = await pnDAO.GetReaderList(ownerId);

            List<Book> books = await pnDAO.GetBookList(ownerId);

            ViewBag.GetAuthorList = books.GroupBy(x => x.Author).Select(y => y.First());

            ViewBag.GetBookNameList = books.GroupBy(x => x.Name).Select(y => y.First());

            return View();
        }

        // POST: PromissoryNotes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(/*[Bind(Include = "Id,ReaderId,UserId,OwnerId,BookId,BorrowedDate,ExpiryDate,Cost,Status")]*/ PromissoryNote promissoryNote)
        {
            promissoryNote.Id = pnId;

            if (ModelState.IsValid)
            {
                if (await pnDAO.Add(promissoryNote))
                {
                    TempData["AlertSuccessMessage"] = "Tạo phiếu thành công!";

                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    TempData["AlertErrorMessage"] = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                    return View(promissoryNote);
                }
            }

            //ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", promissoryNote.OwnerId);
            //ViewBag.ReaderId = new SelectList(db.Readers, "Id", "OwnerId", promissoryNote.ReaderId);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Name", promissoryNote.UserId);
            return View(promissoryNote);
        }

        // GET: PromissoryNotes/Edit/5
        public ActionResult Edit(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //PromissoryNote promissoryNote = db.PromissoryNotes.Find(id);
            //if (promissoryNote == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", promissoryNote.OwnerId);
            //ViewBag.ReaderId = new SelectList(db.Readers, "Id", "OwnerId", promissoryNote.ReaderId);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Name", promissoryNote.UserId);
            return View(/*promissoryNote*/);
        }

        // POST: PromissoryNotes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReaderId,UserId,OwnerId,BookId,BorrowedDate,ExpiryDate,Cost,Status")] PromissoryNote promissoryNote)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(promissoryNote).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", promissoryNote.OwnerId);
            //ViewBag.ReaderId = new SelectList(db.Readers, "Id", "OwnerId", promissoryNote.ReaderId);
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Name", promissoryNote.UserId);
            return View(promissoryNote);
        }

        // GET: PromissoryNotes/Delete/5
        public ActionResult Delete(string id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //PromissoryNote promissoryNote = db.PromissoryNotes.Find(id);
            //if (promissoryNote == null)
            //{
            //    return HttpNotFound();
            //}
            return View(/*promissoryNote*/);
        }

        // POST: PromissoryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //PromissoryNote promissoryNote = db.PromissoryNotes.Find(id);
            //db.PromissoryNotes.Remove(promissoryNote);
            //db.SaveChanges();
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

        [HttpPost]
        public async Task<JsonResult> GetReaderId(string readerPhone)
        {
            var getReader = await pnDAO.GetReaderId(readerPhone, (string)Session["ownerId"]);

            if (getReader != null)
            {
                return Json(new { success = true, readerId = getReader.Id }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> GetBookId(string bookName, string bookAuthor)
        {
            var getBook = await pnDAO.GetBookId(bookName, bookAuthor, (string)Session["ownerId"]);

            if (getBook != null)
            {
                return Json(new { success = true, bookId = getBook.Id }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
