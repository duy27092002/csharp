using LibraryManageWebsite.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LibraryManageWebsite.Controllers
{
    public class HomeController : Controller
    {
        private ReaderDAO readerDAO = new ReaderDAO();

        private BookDAO bookDAO = new BookDAO();

        private UserDAO userDAO = new UserDAO();

        private PromissoryNoteDAO pnDAO = new PromissoryNoteDAO();

        [Authorize(Roles = "Admin, Nhân viên")]
        public async Task<ActionResult> Index()
        {
            var ownerId = (string)Session["ownerId"];

            // lấy số lượng đọc giả đã đăng ký dịch vụ
            var getReaderList = await readerDAO.GetReaderList(ownerId);

            ViewBag.CountOfReader = getReaderList.Count();

            // lấy số lượng sách có trong thư viện (số lượng sách > 0)
            var getBookList = await bookDAO.GetBookList(ownerId);

            ViewBag.CountOfBook = getBookList.Count();

            // lấy số lượng nhân viên đang làm việc trong thư viện
            var getUserList = await userDAO.GetAllUserByStatus(ownerId);

            ViewBag.CountOfUser = getUserList.Count();

            // lấy số lượng các loại phiếu
            // phiếu đang mượn
            var getBorrowedPN = await pnDAO.GetAllByStatus(ownerId, 0);

            ViewBag.CountOfBorrowedPN = getBorrowedPN.Count();

            // phiếu đã trả
            var getReturnedPN = await pnDAO.GetAllByStatus(ownerId, 1);

            ViewBag.CountOfReturnedPN = getReturnedPN.Count();

            // phiếu đã trễ hạn
            var getLatedPN = await pnDAO.GetAllByStatus(ownerId, 2);

            ViewBag.CountOfLatedPN = getLatedPN.Count();

            return View();
        }

        [Authorize(Roles = "Admin, Nhân viên, Developer")]
        public ActionResult Error()
        {
            return View();
        }
    }
}