using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T3H_K34DL1_WebMVC5.Controllers
{
    public class BTController : Controller
    {
        // GET: BT
        public ActionResult Index()
        {
            return View();
        }

        // GET: BT/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BT/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BT/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BT/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BT/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BT/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
