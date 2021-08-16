using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using T3H_K34DL1_WebMVC5.Models;

namespace T3H_K34DL1_WebMVC5.Controllers
{
    public class ItemController : Controller
    {
        public static List<Item> items_;

        public ItemController()
        {
            if (items_ == null)
            {
                items_ = new List<Item>();
            }
        }
        // GET: Item
        public ActionResult Index()
        {
            return View(items_);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            try
            {
                items_.Add(item);
                return RedirectToAction(nameof(Index));
            } catch(Exception ex)
            {

            }
            return View();
        }

        public ActionResult Edit(string id)
        {
            var item = items_.Where(t => t.ID == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {

            var item0 = items_.Where(t => t.ID == item.ID).FirstOrDefault();
            item0.Name = item.Name;
            item0.Count = item.Count;
            item0.Price = item.Price;
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Details(string id)
        {
            var item = items_.Where(t => t.ID == id).FirstOrDefault();
            return View(item);
        }

        public ActionResult Delete(string id)
        {
            var item = items_.Where(t => t.ID == id).FirstOrDefault();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            var item = items_.Where(t => t.ID == id).FirstOrDefault();
            items_.Remove(item);
            return RedirectToAction(nameof(Index));
        }
    }
}