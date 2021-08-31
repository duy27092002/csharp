using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppMVC5.Models.EF;

namespace WebAppMVC5.Controllers
{
    public class SendMailController : Controller
    {
        // GET: SendMail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(MailInfo mailInfo)
        {
            string msg = "";

            if (mailInfo != null)
            {
                try
                {
                    // cấu hình thông tin email gửi đi
                    var mail = new SmtpClient("smtp.gmail.com", 25)
                    {
                        Credentials = new NetworkCredential("nhacthugiangoodlife@gmail.com", "GoodLife2$209"),
                        EnableSsl = true
                    };

                    // dữ liệu email
                    var message = new MailMessage();
                    message.From = new MailAddress("nhacthugiangoodlife@gmail.com");
                    message.To.Add(mailInfo.To);
                    message.Subject = mailInfo.Subject;
                    message.Body = mailInfo.Note;

                    // gửi email
                    await mail.SendMailAsync(message);

                    ViewBag.Success = "Gửi mail thành công!";

                    return View();
                } catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }

            ViewBag.Error = "Đã có lỗi xảy ra!\n" + msg;

            return View(mailInfo);
        }
    }
}