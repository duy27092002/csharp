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
    public class SupplierController : Controller
    {
        private DB_QLBanDongHoEntities1 db = new DB_QLBanDongHoEntities1();

        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View(db.tb_supplier.ToList());
        }

        // GET: Admin/Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_supplier tb_supplier = db.tb_supplier.Find(id);
            if (tb_supplier == null)
            {
                return HttpNotFound();
            }
            return View(tb_supplier);
        }

        // GET: Admin/Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "supplierID,name,address,EMail,phonenumber")] tb_supplier tb_supplier)
        {
            if (ModelState.IsValid)
            {
                db.tb_supplier.Add(tb_supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_supplier);
        }

        // GET: Admin/Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_supplier tb_supplier = db.tb_supplier.Find(id);
            if (tb_supplier == null)
            {
                return HttpNotFound();
            }
            return View(tb_supplier);
        }

        // POST: Admin/Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "supplierID,name,address,EMail,phonenumber")] tb_supplier tb_supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_supplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_supplier);
        }

        // GET: Admin/Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_supplier tb_supplier = db.tb_supplier.Find(id);
            if (tb_supplier == null)
            {
                return HttpNotFound();
            }
            return View(tb_supplier);
        }

        // POST: Admin/Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_supplier tb_supplier = db.tb_supplier.Find(id);
            db.tb_supplier.Remove(tb_supplier);
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
