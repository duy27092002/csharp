﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManageWebsite.Models.EF;

namespace LibraryManageWebsite.Controllers
{
    public class PromissoryNotesController : Controller
    {
        private DB_LibraryManagementWebsiteEntities db = new DB_LibraryManagementWebsiteEntities();

        // GET: PromissoryNotes
        public ActionResult Index()
        {
            var promissoryNotes = db.PromissoryNotes.Include(p => p.Owner).Include(p => p.Reader).Include(p => p.User);
            return View(promissoryNotes.ToList());
        }

        // GET: PromissoryNotes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromissoryNote promissoryNote = db.PromissoryNotes.Find(id);
            if (promissoryNote == null)
            {
                return HttpNotFound();
            }
            return View(promissoryNote);
        }

        // GET: PromissoryNotes/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name");
            ViewBag.ReaderId = new SelectList(db.Readers, "Id", "OwnerId");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: PromissoryNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReaderId,UserId,OwnerId,Total,Status")] PromissoryNote promissoryNote)
        {
            if (ModelState.IsValid)
            {
                db.PromissoryNotes.Add(promissoryNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", promissoryNote.OwnerId);
            ViewBag.ReaderId = new SelectList(db.Readers, "Id", "OwnerId", promissoryNote.ReaderId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", promissoryNote.UserId);
            return View(promissoryNote);
        }

        // GET: PromissoryNotes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromissoryNote promissoryNote = db.PromissoryNotes.Find(id);
            if (promissoryNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", promissoryNote.OwnerId);
            ViewBag.ReaderId = new SelectList(db.Readers, "Id", "OwnerId", promissoryNote.ReaderId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", promissoryNote.UserId);
            return View(promissoryNote);
        }

        // POST: PromissoryNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReaderId,UserId,OwnerId,Total,Status")] PromissoryNote promissoryNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promissoryNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", promissoryNote.OwnerId);
            ViewBag.ReaderId = new SelectList(db.Readers, "Id", "OwnerId", promissoryNote.ReaderId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", promissoryNote.UserId);
            return View(promissoryNote);
        }

        // GET: PromissoryNotes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromissoryNote promissoryNote = db.PromissoryNotes.Find(id);
            if (promissoryNote == null)
            {
                return HttpNotFound();
            }
            return View(promissoryNote);
        }

        // POST: PromissoryNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PromissoryNote promissoryNote = db.PromissoryNotes.Find(id);
            db.PromissoryNotes.Remove(promissoryNote);
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