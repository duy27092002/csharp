﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManageWebsite.Controllers
{
    [Authorize(Roles = "Admin, Nhân viên")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}