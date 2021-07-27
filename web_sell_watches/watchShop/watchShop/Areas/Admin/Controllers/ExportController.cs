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
    public class ExportController : Controller
    {
        private DB_QLBanDongHoEntities1 db = new DB_QLBanDongHoEntities1();

        // GET: Admin/Export
        public ActionResult Index()
        {
            var tb_export_invoice = db.tb_export_invoice.Include(t => t.tb_users).Include(t => t.tb_users1);
            return View(tb_export_invoice.ToList());
        }

        // GET: Admin/Export/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_export_invoice tb_export_invoice = db.tb_export_invoice.Find(id);
            if (tb_export_invoice == null)
            {
                return HttpNotFound();
            }
            return View(tb_export_invoice);
        }

        // GET: Admin/Export/Create
        public ActionResult Create()
        {
            tb_export_invoice model = new tb_export_invoice()
            {
                time = DateTime.Now,
            };

            ViewBag.staffID = new SelectList(db.tb_users, "userID", "name");
            ViewBag.customerID = new SelectList(db.tb_users, "userID", "name");

            // lấy danh sách nhân viên trong bảng tb_users để trả ra DropdownList
            ViewBag.staffList = new SelectList(db.tb_users.Where(t => t.isStaff == true), "userID", "name");

            // lấy danh sách khách hàng trong bảng tb_users để trả ra DropdownList
            ViewBag.customerList = new SelectList(db.tb_users.Where(t => t.isCustomer == true), "userID", "name");

            // lấy danh sách loại đồng hồ, hiển thị tên nhưng chọn categoryID
            ViewBag.Category = new SelectList(db.tb_category, "categoryID", "name");

            return View(model);
        }

        // POST: Admin/Export/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "exportInvoiceID,staffID,customerID,time,totalPrice")] tb_export_invoice tb_export_invoice)
        {
            if (ModelState.IsValid)
            {
                db.tb_export_invoice.Add(tb_export_invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.staffID = new SelectList(db.tb_users, "userID", "name", tb_export_invoice.staffID);
            ViewBag.customerID = new SelectList(db.tb_users, "userID", "name", tb_export_invoice.customerID);
            return View(tb_export_invoice);
        }

        // GET: Admin/Export/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_export_invoice tb_export_invoice = db.tb_export_invoice.Find(id);
            if (tb_export_invoice == null)
            {
                return HttpNotFound();
            }
            //ViewBag.userID = new SelectList(db.tb_users, "userID", "name", tb_export_invoice.staffID);

            // lấy danh sách nhân viên trong bảng tb_users để trả ra DropdownList
            ViewBag.staffList = new SelectList(db.tb_users.Where(t => t.isStaff == true), "userID", "name");

            // lấy danh sách khách hàng trong bảng tb_users để trả ra DropdownList
            ViewBag.customerList = new SelectList(db.tb_users.Where(t => t.isCustomer == true), "userID", "name");

            // lấy danh sách loại đồng hồ, hiển thị tên nhưng chọn categoryID
            ViewBag.Category = new SelectList(db.tb_category, "categoryID", "name");
            return View(tb_export_invoice);
        }

        // POST: Admin/Export/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "exportInvoiceID,staffID,customerID,time,totalPrice")] tb_export_invoice tb_export_invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_export_invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.userID = new SelectList(db.tb_users, "userID", "name", tb_export_invoice.staffID);
            return View(tb_export_invoice);
        }

        // GET: Admin/Export/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_export_invoice tb_export_invoice = db.tb_export_invoice.Find(id);
            if (tb_export_invoice == null)
            {
                return HttpNotFound();
            }
            return View(tb_export_invoice);
        }

        // POST: Admin/Export/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_export_invoice tb_export_invoice = db.tb_export_invoice.Find(id);
            db.tb_export_invoice.Remove(tb_export_invoice);
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
