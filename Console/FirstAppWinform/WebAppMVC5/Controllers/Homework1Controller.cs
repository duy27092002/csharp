using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppMVC5.Models.EF;

namespace WebAppMVC5.Controllers
{
    public class Homework1Controller : Controller
    {
        // GET: Homework1
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Homework1 data)
        {
            double a = data.FirstOrderCoefficient;
            double b = data.SecondOrderCoefficient;
            double c = data.CoefficientOfFreedom;
            double delta = b * b - 4 * a * c;
            double x1, x2;

            if (delta > 0)
            {
                if (a != 0)
                {
                    x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    ViewBag.Result = "Phương trình có 2 nghiệm là: x1 = " + x1 + " và x2 = " + x2;
                }
                else
                {
                    ViewBag.Result = "Phương trình có nghiệm duy nhất là: x = " + (-c / b);
                }
            }
            else if (delta < 0)
            {
                ViewBag.Result = "Phương trình vô nghiệm";
            }
            else
            {
                if (a != 0)
                    ViewBag.Result = "Phương trình có nghiệm duy nhất là: x = " + (-b / (2 * a));
                else
                {
                    if (c == 0)
                        ViewBag.Result = "Phương trình có vô số nghiệm";
                    else
                        ViewBag.Result = "Phương trình vô nghiệm";
                }
            }

            return View();
        }
    }
}