﻿using LibraryManageWebsite.Models.DAO;
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
            else if (accountDAO.IsDeveloper(user))
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
            ViewBag.UserId = BaseDAO.RandomString(10);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
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