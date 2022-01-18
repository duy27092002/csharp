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

        private ReaderDAO readerDAO = new ReaderDAO();

        private BookDAO bookDAO = new BookDAO();

        private UserDAO userDAO = new UserDAO();

        string pnId = BaseDAO.RandomString(10);

        string msg;

        // trả ra danh sách phiếu đang mượn và đã trễ hạn
        // GET: PromissoryNotes
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var ownerId = (string)Session["ownerId"];

            var getPNList = await pnDAO.GetByPaged(page, pageSize, keyword, ownerId);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(getPNList);
        }

        // trả ra danh sách phiếu đã trả
        public async Task<ActionResult> ReturnedBookList(int page = 1, int pageSize = 10, string keyword = "")
        {
            var ownerId = (string)Session["ownerId"];

            var getPNList = await pnDAO.GetByPagedForReturnedBookList(page, pageSize, keyword, ownerId);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(getPNList);
        }

        // GET: PromissoryNotes/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            PromissoryNote promissoryNote = await pnDAO.GetById(id);

            if (promissoryNote == null || Session["ownerId"] == null || promissoryNote.OwnerId != (string)Session["ownerId"])
            {
                return RedirectToAction("Error", "Home");
            }

            return View(promissoryNote);
        }

        // GET: PromissoryNotes/Create
        public async Task<ActionResult> Create()
        {
            var getNameOfUser = await userDAO.GetById((string)Session["userId"]);

            ViewBag.NameOfUser = getNameOfUser.Name;

            var ownerId = (string)(Session["ownerId"]);

            ViewBag.GetReaderList = await readerDAO.GetReaderList(ownerId);

            List<Book> books = await bookDAO.GetBookList(ownerId);

            ViewBag.GetAuthorList = books.GroupBy(x => x.Author).Select(y => y.First());

            ViewBag.GetBookNameList = books.GroupBy(x => x.Name).Select(y => y.First());

            return View();
        }

        // POST: PromissoryNotes/Create
        [HttpPost]
        public async Task<JsonResult> CreateConfirmed(PromissoryNote promissoryNote, string readerPhone, string bookName, string bookAuthor)
        {
            var ownerId = (string)(Session["ownerId"]);

            var getReaderId = await readerDAO.GetReaderId(readerPhone, ownerId);

            var getBookId = await bookDAO.GetBookId(bookName, bookAuthor, ownerId);

            if (getReaderId == null)
            {
                msg = "Số điện thoại không tồn tại. Vui lòng thử lại!";

                return Json(new { success = false, mess = msg }, JsonRequestBehavior.AllowGet);
            }
            else if (getBookId == null)
            {
                msg = "Thông tin sách không chính xác. Vui lòng thử lại!";

                return Json(new { success = false, mess = msg }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                promissoryNote.Id = pnId;
                promissoryNote.ReaderId = getReaderId.Id;
                promissoryNote.BookId = getBookId.Id;

                if (await pnDAO.Add(promissoryNote))
                {
                    // cập nhật số lượng, số lượt mượn cho sách tương ứng --> giảm số lượng, tăng lượt mượn
                    if (await bookDAO.UpdateQuantityAndViews(promissoryNote.BookId, 0))
                    {
                        TempData["AlertSuccessMessage"] = "Tạo phiếu thành công!";

                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                    }
                }

                msg = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                return Json(new { success = false, mess = msg }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: PromissoryNotes/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            PromissoryNote promissoryNote = await pnDAO.GetById(id);

            if (promissoryNote == null || Session["ownerId"] == null || promissoryNote.OwnerId != (string)Session["ownerId"])
            {
                return RedirectToAction("Error", "Home");
            }

            #region lấy dữ liệu khởi tạo ban đầu

            var ownerId = (string)(Session["ownerId"]);

            ViewBag.GetReaderList = await readerDAO.GetReaderList(ownerId);

            List<Book> books = await bookDAO.GetBookList(ownerId);

            ViewBag.GetAuthorList = books.GroupBy(x => x.Author).Select(y => y.First());

            ViewBag.GetBookNameList = books.GroupBy(x => x.Name).Select(y => y.First());

            #endregion

            return View(promissoryNote);
        }

        // POST: PromissoryNotes/Edit/5
        // phương thức này sử dụng khi thông tin sách được thay đổi
        [HttpPost]
        public async Task<JsonResult> EditAndChangeBookInfo(PromissoryNote promissoryNote, string readerPhone, string newBookName, string newBookAuthor, 
            string oldBookName, string oldBookAuthor)
        {
            var ownerId = (string)(Session["ownerId"]);

            var getReaderId = await readerDAO.GetReaderId(readerPhone, ownerId);

            // lấy thông tin sách mới (sách thay thế)
            var getNewBookId = await bookDAO.GetBookId(newBookName, newBookAuthor, ownerId);

            // lấy thông tin sách cũ (sách bị thay thế)
            var getOldBook = await bookDAO.GetAllBookId(oldBookName, oldBookAuthor, ownerId);

            if (getReaderId == null)
            {
                msg = "Số điện thoại không tồn tại. Vui lòng thử lại!";

                return Json(new { success = false, mess = msg }, JsonRequestBehavior.AllowGet);
            }
            else if (getNewBookId == null)
            {
                msg = "Thông tin sách không chính xác. Vui lòng thử lại!";

                return Json(new { success = false, mess = msg }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                promissoryNote.ReaderId = getReaderId.Id;
                promissoryNote.BookId = getNewBookId.Id; // id sách mới

                if (await pnDAO.Update(promissoryNote))
                {
                    // cập nhật lại lượt mượn cho 2 loại sách
                    // với sách cũ thì giảm lượt mượn đi 1 (-1), tăng số lượng lên 1 (+1) --> type = 2
                    // với sách mới thì tăng lượt mượn lên 1 (+1), giảm số lượng đi 1 (-1) --> type = 0
                    // để làm được điều này cần có: id sách CŨ & MỚI (ở đây chỉ có id sách mới)
                    if (await bookDAO.UpdateQuantityAndViews(getOldBook.Id, 2) &&
                        await bookDAO.UpdateQuantityAndViews(promissoryNote.BookId, 0))
                    {
                        TempData["AlertSuccessMessage"] = "Cập nhật phiếu thành công!";

                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                    }
                }

                msg = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                return Json(new { success = false, mess = msg }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: PromissoryNotes/Edit/5
        // phương thức này sử dụng khi thông tin sách không thay đổi
        // tránh trường hợp số lượng sách thuộc phiếu đang sửa = 0
        [HttpPost]
        public async Task<JsonResult> EditAndDoNotChangeBookInfo(PromissoryNote promissoryNote, string readerPhone, string bookName, string bookAuthor)
        {
            var ownerId = (string)(Session["ownerId"]);

            var getReaderId = await readerDAO.GetReaderId(readerPhone, ownerId);

            var getBookId = await bookDAO.GetAllBookId(bookName, bookAuthor, ownerId);

            if (getReaderId == null)
            {
                msg = "Số điện thoại không tồn tại. Vui lòng thử lại!";

                return Json(new { success = false, mess = msg }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                promissoryNote.ReaderId = getReaderId.Id;
                promissoryNote.BookId = getBookId.Id;

                if (await pnDAO.Update(promissoryNote))
                {
                    TempData["AlertSuccessMessage"] = "Cập nhật phiếu thành công!";

                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    msg = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                    return Json(new { success = false, mess = msg }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        // trả sách
        public async Task<ActionResult> ReturningBook(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            PromissoryNote promissoryNote = await pnDAO.GetById(id);

            if (promissoryNote == null || Session["ownerId"] == null || promissoryNote.OwnerId != (string)Session["ownerId"])
            {
                return RedirectToAction("Error", "Home");
            }

            return View(promissoryNote);
        }

        [HttpPost, ActionName("ReturningBook")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ReturningBookConfirmed(string id)
        {
            PromissoryNote promissoryNote = await pnDAO.GetById(id);

            if (promissoryNote.Status == 1)
            {
                TempData["AlertWarningMessage"] = "Sách ở phiếu này đã được trả!";

                return View(promissoryNote);
            }
            else
            {
                if (await pnDAO.UpdateStatus(id))
                {
                    if (await bookDAO.UpdateQuantityAndViews(promissoryNote.BookId, 1))
                    {
                        TempData["AlertSuccessMessage"] = "Trả sách thành công!";

                        return RedirectToAction("Index");
                    }
                }

                TempData["AlertErrorMessage"] = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                return View(promissoryNote);
            }
        }

        // GET: PromissoryNotes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            PromissoryNote promissoryNote = await pnDAO.GetById(id);

            if (promissoryNote == null || Session["ownerId"] == null || promissoryNote.OwnerId != (string)Session["ownerId"])
            {
                return RedirectToAction("Error", "Home");
            }

            return View(promissoryNote);
        }

        // POST: PromissoryNotes/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            PromissoryNote promissoryNote = await pnDAO.GetById(id);

            if (await pnDAO.Delete(id))
            {
                TempData["AlertSuccessMessage"] = "Xóa phiếu thành công!";

                return RedirectToAction("ReturnedBookList");
            }
            else
            {
                TempData["AlertErrorMessage"] = "Xóa phiếu thất bại. Vui lòng thử lại!";

                return View(promissoryNote);
            }
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
