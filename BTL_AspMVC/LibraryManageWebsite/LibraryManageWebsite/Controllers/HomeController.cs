using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManageWebsite.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Admin, Nhân viên")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Nhân viên, Developer")]
        public ActionResult Error()
        {
            return View();
        }
    }
}