using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using watchShop.Models.EF;

namespace watchShop.Controllers
{
    public class UserController : Controller
    {
        /*// GET: User
        public ActionResult Index()
        {
            return View();
        }*/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tb_users user)
        {
            // kiểm tra login ở đây

            return Redirect("/Home/Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(tb_users user)
        {
            // kiểm tra register ở đây

            return View("Login");
        }
    }
}