using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T3H_K34DL1_WebMVC5.Models.DAO;

namespace T3H_K34DL1_WebMVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeDAO dao = new HomeDAO();

            var date = new DateTime();
            date.AddDays(DateTime.Now.Day);

            ViewBag.TongSoDonNhap = string.Format("{0:0,0}", dao.GetTongSoDonNhap(date, DateTime.Now));
            ViewBag.TongSoDonXuat = string.Format("{0:0,0}", dao.GetTongSoDonXuat(date, DateTime.Now));
            ViewBag.DoanhThu = string.Format("{0:0,0}", dao.GetDoanhThu(date, DateTime.Now));
            ViewBag.LoiNhuan = string.Format("{0:0,0}", dao.GetLoiNhuan(date, DateTime.Now));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string GetName()
        {
            return "Nguyễn Văn Duy";
        }
        [HttpGet]
        public JsonResult GetJson()
        {
            return Json(new { data = "T3H", value = "Chào buổi sáng!" }, JsonRequestBehavior.AllowGet);
        }
    }
}