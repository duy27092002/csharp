﻿using System;
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
    public class ProductController : Controller
    {
        private DB_QLBanDongHoEntities1 db = new DB_QLBanDongHoEntities1();

        // GET: Admin/Product
        public ActionResult Index()
        {
            var tb_products = db.tb_products.Include(t => t.tb_category).Include(t => t.tb_producer);
            return View(tb_products.ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_products tb_products = db.tb_products.Find(id);
            if (tb_products == null)
            {
                return HttpNotFound();
            }
            return View(tb_products);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.tb_category, "categoryID", "name");
            ViewBag.producerID = new SelectList(db.tb_producer, "producerID", "name");
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "watchID,name,categoryID,amount,price,color,desc_,pic,producerID")] tb_products tb_products)
        {
            if (ModelState.IsValid)
            {
                db.tb_products.Add(tb_products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.tb_category, "categoryID", "name", tb_products.categoryID);
            ViewBag.producerID = new SelectList(db.tb_producer, "producerID", "name", tb_products.producerID);
            return View(tb_products);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_products tb_products = db.tb_products.Find(id);
            if (tb_products == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.tb_category, "categoryID", "name", tb_products.categoryID);
            ViewBag.producerID = new SelectList(db.tb_producer, "producerID", "name", tb_products.producerID);
            return View(tb_products);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "watchID,name,categoryID,amount,price,color,desc_,pic,producerID")] tb_products tb_products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.tb_category, "categoryID", "name", tb_products.categoryID);
            ViewBag.producerID = new SelectList(db.tb_producer, "producerID", "name", tb_products.producerID);
            return View(tb_products);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_products tb_products = db.tb_products.Find(id);
            if (tb_products == null)
            {
                return HttpNotFound();
            }
            return View(tb_products);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_products tb_products = db.tb_products.Find(id);
            db.tb_products.Remove(tb_products);
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
