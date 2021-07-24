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
    public class InportController : Controller
    {
        private DB_QLBanDongHoEntities1 db = new DB_QLBanDongHoEntities1();

        // GET: Admin/Inport
        public ActionResult Index()
        {
            var tb_inport_invoice = db.tb_inport_invoice.Include(t => t.tb_supplier).Include(t => t.tb_users);
            return View(tb_inport_invoice.ToList());
        }

        // GET: Admin/Inport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_inport_invoice tb_inport_invoice = db.tb_inport_invoice.Find(id);
            if (tb_inport_invoice == null)
            {
                return HttpNotFound();
            }
            return View(tb_inport_invoice);
        }

        // GET: Admin/Inport/Create
        public ActionResult Create()
        {
            ViewBag.supplierID = new SelectList(db.tb_supplier, "supplierID", "name");
            ViewBag.staffID = new SelectList(db.tb_users, "userID", "name");

            // lấy danh sách nhân viên trong bảng tb_users để trả ra DropdownList
            ViewBag.staffList = new SelectList(db.tb_users.Where(t => t.isStaff == true), "userID", "name");
            // lấy danh sách loại đồng hồ, hiển thị tên nhưng chọn categoryID
            ViewBag.Category = new SelectList(db.tb_category, "categoryID", "name");
            return View();
        }

        // POST: Admin/Inport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "inportInvoiceID,supplierID,time,staffID,totalPrice")] tb_inport_invoice tb_inport_invoice)
        {
            if (ModelState.IsValid)
            {
                db.tb_inport_invoice.Add(tb_inport_invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.supplierID = new SelectList(db.tb_supplier, "supplierID", "name", tb_inport_invoice.supplierID);
            ViewBag.staffID = new SelectList(db.tb_users, "userID", "name", tb_inport_invoice.staffID);
            return View(tb_inport_invoice);
        }

        // GET: Admin/Inport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_inport_invoice tb_inport_invoice = db.tb_inport_invoice.Find(id);
            if (tb_inport_invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.supplierID = new SelectList(db.tb_supplier, "supplierID", "name", tb_inport_invoice.supplierID);
            ViewBag.staffID = new SelectList(db.tb_users, "userID", "name", tb_inport_invoice.staffID);

            // lấy danh sách loại đồng hồ, hiển thị tên nhưng chọn categoryID
            ViewBag.Category = new SelectList(db.tb_category, "categoryID", "name");
            return View(tb_inport_invoice);
        }

        // POST: Admin/Inport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "inportInvoiceID,supplierID,time,staffID,totalPrice")] tb_inport_invoice tb_inport_invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_inport_invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.supplierID = new SelectList(db.tb_supplier, "supplierID", "name", tb_inport_invoice.supplierID);
            ViewBag.staffID = new SelectList(db.tb_users, "userID", "name", tb_inport_invoice.staffID);
            return View(tb_inport_invoice);
        }

        // GET: Admin/Inport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_inport_invoice tb_inport_invoice = db.tb_inport_invoice.Find(id);
            if (tb_inport_invoice == null)
            {
                return HttpNotFound();
            }
            return View(tb_inport_invoice);
        }

        // POST: Admin/Inport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_inport_invoice tb_inport_invoice = db.tb_inport_invoice.Find(id);
            db.tb_inport_invoice.Remove(tb_inport_invoice);
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
