using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T3H_K34DL1_WebMVC5.Controllers
{
    public class T3HController : Controller
    {
        // GET: T3H
        public ActionResult Index()
        {
            int[] nums = { 1,2,3,4,5,6,3,6,7,4,3};
            ViewBag.Nums = nums;
            ViewData["Nums"] = nums;
            return View(nums);
        }
        public ActionResult Create()
        {
            return View();
        }

        // phương thức mặc định ở đây là GET
        public ActionResult Submit(string name, bool gender, int age, string classes, string des)
        {
            ViewBag.Name = name;
            ViewBag.Gender = gender;
            //ViewData["Gender"] = gender;
            ViewBag.Age = age;
            ViewBag.Classes = classes;
            ViewBag.Des = des;
            return View();
        }

        [HttpPost]
        public ActionResult Submit(FormCollection form)
        {
            ViewBag.Name = form["name"];
            ViewBag.Gender = form["gender"];
            //ViewData["Gender"] = gender;
            ViewBag.Age = form["age"];
            ViewBag.Classes = form["classes"];
            ViewBag.Des = form["des"];
            return View();
        }
    }
}