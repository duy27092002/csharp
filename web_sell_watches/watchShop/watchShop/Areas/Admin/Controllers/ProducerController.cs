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
    public class ProducerController : Controller
    {
        private DB_QLBanDongHoEntities1 db = new DB_QLBanDongHoEntities1();

        // GET: Admin/Producer
        public ActionResult Index()
        {
            return View(db.tb_producer.ToList());
        }

        // GET: Admin/Producer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_producer tb_producer = db.tb_producer.Find(id);
            if (tb_producer == null)
            {
                return HttpNotFound();
            }
            return View(tb_producer);
        }

        // GET: Admin/Producer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Producer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "producerID,name,address,EMail,phonenumber")] tb_producer tb_producer)
        {
            if (ModelState.IsValid)
            {
                db.tb_producer.Add(tb_producer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_producer);
        }

        // GET: Admin/Producer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_producer tb_producer = db.tb_producer.Find(id);
            if (tb_producer == null)
            {
                return HttpNotFound();
            }
            return View(tb_producer);
        }

        // POST: Admin/Producer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "producerID,name,address,EMail,phonenumber")] tb_producer tb_producer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_producer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_producer);
        }

        // GET: Admin/Producer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_producer tb_producer = db.tb_producer.Find(id);
            if (tb_producer == null)
            {
                return HttpNotFound();
            }
            return View(tb_producer);
        }

        // POST: Admin/Producer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_producer tb_producer = db.tb_producer.Find(id);
            db.tb_producer.Remove(tb_producer);
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
