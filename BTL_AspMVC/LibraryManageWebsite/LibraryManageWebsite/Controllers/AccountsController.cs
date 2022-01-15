using LibraryManageWebsite.Models.DAO;
using LibraryManageWebsite.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryManageWebsite.Controllers
{
    public class AccountsController : Controller
    {
        private AccountDAO accountDAO = new AccountDAO();

        private OwnerDAO ownerDAO = new OwnerDAO();

        string userId = BaseDAO.RandomString(10);

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (accountDAO.CheckLogin(user))
            {
                var getUser = accountDAO.GetUser(user);

                if (getUser.UserType != 3)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    
                    Session["username"] = user.Username;

                    Session["userId"] = getUser.Id;

                    Session["ownerId"] = user.OwnerId;

                    var getOwnerInfo = ownerDAO.GetOwner(user.OwnerId);

                    TimeSpan days = (DateTime.Parse(getOwnerInfo.ExpireTime.ToShortDateString()) - DateTime.Today);

                    if (days.TotalDays <= 30 && days.TotalDays > 0 && getUser.UserType == 0)
                    {
                        TempData["AlertWarningMessage"] = "Thời hạn thuê Website sắp hết (chỉ còn " + days.TotalDays + " ngày). Vui lòng liên hệ với Developer để gia hạn!";
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            if (user.OwnerId == null && user.Username == "DnV" && user.Email == "dnvduynguyen@gmail.com" && user.Password == "27092002")
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);

                Session["username"] = user.Username;

                Session["userId"] = accountDAO.GetInfoOfDev(user).Id;

                return RedirectToAction("Index", "Owners");
            }

            TempData["AlertErrorMessage"] = "Sai thông tin đăng nhập hoặc là bạn không được cho phép đăng nhập. Vui lòng thử lại!";

            return View(user);
        }

        // GET: Sign in
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            user.Id = userId;

            if (ModelState.IsValid)
            {
                if (accountDAO.CheckUsername(user.Username) == false)
                {
                    TempData["AlertErrorMessage"] = "Tên đăng nhập này đã tồi tại. Xin hãy đổi lại!";
                }
                else if (accountDAO.CheckEmail(user.Email) == false)
                {
                    TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại email!";
                }
                else if (accountDAO.CheckPhone(user.Phone) == false)
                {
                    TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại số điện thoại!";
                }
                else if (accountDAO.CheckOwnerId(user.OwnerId) == false)
                {
                    TempData["AlertErrorMessage"] = "Mã xác minh không hợp lệ!";
                }
                else
                {
                    accountDAO.AddNewUser(user);

                    return RedirectToAction("Login");
                }
            }

            return View(user);
        }

        // GET: Forgot Password
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // Logout
        public ActionResult Logout()
        {
            Session.Clear();

            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}