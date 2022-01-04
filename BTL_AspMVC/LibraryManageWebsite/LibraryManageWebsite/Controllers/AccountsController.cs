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
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["username"] = user.Username;

                Session["userId"] = accountDAO.GetUser(user).Id;

                Session["ownerId"] = user.OwnerId;

                return RedirectToAction("Index", "Home");
            }

            TempData["AlertErrorMessage"] = "Sai thông tin đăng nhập. Vui lòng kiểm tra lại!";

            return View(user);
        }

        // GET: Sign in
        public ActionResult SignIn()
        {
            ViewBag.UserId = BaseDAO.RandomString(10);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            if (ModelState.IsValid)
            {
                if (accountDAO.CheckOwnerId(user.OwnerId))
                {
                    accountDAO.AddNewUser(user);

                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["AlertErrorMessage"] = "Mã xác minh không hợp lệ!";
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