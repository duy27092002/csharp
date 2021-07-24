using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using watchShop.Models.EF;

namespace watchShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private DB_QLBanDongHoEntities1 db = new DB_QLBanDongHoEntities1();

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.tb_category.ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_category tb_category = db.tb_category.Find(id);
            if (tb_category == null)
            {
                return HttpNotFound();
            }
            return View(tb_category);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryID,name")] tb_category tb_category)
        {
            if (ModelState.IsValid)
            {
                db.tb_category.Add(tb_category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_category tb_category = db.tb_category.Find(id);
            if (tb_category == null)
            {
                return HttpNotFound();
            }
            return View(tb_category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryID,name")] tb_category tb_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_category);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_category tb_category = db.tb_category.Find(id);
            if (tb_category == null)
            {
                return HttpNotFound();
            }
            return View(tb_category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_category tb_category = db.tb_category.Find(id);
            db.tb_category.Remove(tb_category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
