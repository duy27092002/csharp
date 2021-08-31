using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC5.Controllers
{
    public class IntroductionController : Controller
    {
        /// <summary>
        /// Tạo 1 view giới thiệu bản thân: họ tên, ngày tháng năm sinh, lớp học, quê quán, địa chỉ cư trú, SĐT
        /// </summary>
        /// <returns></returns>
        // GET: Introduction
        public ActionResult Index()
        {
            ViewBag.Name = "Nguyễn Văn Duy";
            ViewBag.Birthday = "27/09/2002";
            ViewBag.Class = "K34DL1";
            ViewBag.Address = "Sóc Sơn - Hà Nội";
            ViewBag.PhoneNumber = "0367727951";
            return View();
        }
    }
}