using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC5.Models.EF;

namespace WebAppMVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult TextPlain()
        {
            return Content("Đây là content");
        }

        public ActionResult FileContent()
        {
            return File("~/Global.asax.cs", "text/plain");
        }

        public ActionResult JsonContent()
        {
            List<MailInfo> mailInfos = new List<MailInfo>();
            mailInfos.Add(new MailInfo() { To = "minhsaothe1102@gmail.com", Subject = "Tiêu đề 1", Note = "Đây là nội dung json 1" });
            mailInfos.Add(new MailInfo() { To = "sachgiaybut1103@gmail.com", Subject = "Tiêu đề 2", Note = "Đây là nội dung json 2" });
            return Json(mailInfos, JsonRequestBehavior.AllowGet);
        }

        // chia sẻ dữ liệu từ controller sang view
        public ActionResult Mail()
        {
            List<MailInfo> mailInfos = new List<MailInfo>();
            mailInfos.Add(new MailInfo() { To = "minhsaothe1102@gmail.com", Subject = "Tiêu đề 1", Note = "Đây là nội dung json 1" });
            mailInfos.Add(new MailInfo() { To = "sachgiaybut1103@gmail.com", Subject = "Tiêu đề 2", Note = "Đây là nội dung json 2" });
            mailInfos.Add(new MailInfo() { To = "sachgiaybut1103@gmail.com", Subject = "Tiêu đề 3", Note = "Đây là nội dung json 3" });
            mailInfos.Add(new MailInfo() { To = "sachgiaybut1103@gmail.com", Subject = "Tiêu đề 4", Note = "Đây là nội dung json 4" });
            return View(mailInfos);
        }

        public ActionResult Helper()
        {
            List<MailInfo> mailInfos = new List<MailInfo>();
            mailInfos.Add(new MailInfo() { To = "minhsaothe1102@gmail.com", Subject = "Tiêu đề 1", Note = "Đây là nội dung json 1" });
            mailInfos.Add(new MailInfo() { To = "sachgiaybut1103@gmail.com", Subject = "Tiêu đề 2", Note = "Đây là nội dung json 2" });
            mailInfos.Add(new MailInfo() { To = "sachgiaybut1103@gmail.com", Subject = "Tiêu đề 3", Note = "Đây là nội dung json 3" });
            mailInfos.Add(new MailInfo() { To = "sachgiaybut1103@gmail.com", Subject = "Tiêu đề 4", Note = "Đây là nội dung json 4" });

            ViewBag.MailInfos = new SelectList(mailInfos, "To", "To");

            return View();
        }

        public ActionResult StudentRegister()
        {
            ViewBag.Gender = new SelectList(new[]
            {
                new {Name = "Nam", Value = true},
                new {Name = "Nữ", Value = false}
            }, "Value", "Name");
            return View(new Student() { DateOfBirth = new DateTime()});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentRegister(Student student)
        {
            if (ModelState.IsValid) ViewBag.Success = "Đăng ký thành công!";

            ViewBag.Gender = new SelectList(new[]
            {
                new {Name = "Nam", Value = true},
                new {Name = "Nữ", Value = false}
            }, "Value", "Name", student.Gender);
            return View (student);
        }
    }
}