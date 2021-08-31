using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC5.Controllers
{
    public class HelloController : Controller
    {
        // GET: Hello
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SayHello()
        {
            ViewBag.Msg = "Đây là tin nhắn từ ViewBag";
            ViewData["mess"] = "Đây là tin nhắn từ ViewData";

            // trả về view có cùng tên với ActionResult
            return View();
        }
    }
}