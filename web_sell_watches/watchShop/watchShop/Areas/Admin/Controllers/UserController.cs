using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using watchShop.Models.EF;

namespace watchShop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private DB_QLBanDongHoEntities1 db = new DB_QLBanDongHoEntities1();

        // GET: Admin/User
        public ActionResult Index()
        {
            return View(db.tb_users.ToList());
        }

        public ActionResult Admins()
        {
            return View(db.tb_users.ToList());
        }

        public ActionResult Staffs()
        {
            return View(db.tb_users.ToList());
        }

        public ActionResult Customers()
        {
            return View(db.tb_users.ToList());
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_users tb_users = db.tb_users.Find(id);
            if (tb_users == null)
            {
                return HttpNotFound();
            }
            return View(tb_users);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            tb_users tb_Users = new tb_users();
            return View(tb_Users);
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "userID,name,gender,birthday,address,email,phonenumber,userName,password,avatar,isAdmin,isCustomer,isStaff")]*/ tb_users tb_users)
        {
            if (ModelState.IsValid)
            {
                if (tb_users.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(tb_users.ImageUpload.FileName);
                    string extention = Path.GetExtension(tb_users.ImageUpload.FileName);
                    fileName += extention;
                    tb_users.avatar = "~/Content/images/avatars/" + fileName;
                    tb_users.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/avatars/"), fileName));

                    db.tb_users.Add(tb_users);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(tb_users);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_users tb_users = db.tb_users.Find(id);
            if (tb_users == null)
            {
                return HttpNotFound();
            }
            return View(tb_users);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "userID,name,gender,birthday,address,email,phonenumber,userName,password,avatar,isAdmin,isCustomer,isStaff")]*/ tb_users tb_users)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(tb_users.ImageUpload.FileName);
                string extention = Path.GetExtension(tb_users.ImageUpload.FileName);
                fileName += extention;
                tb_users.avatar = "~/Content/images/avatars/" + fileName;
                tb_users.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/avatars/"), fileName));

                db.Entry(tb_users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_users);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_users tb_users = db.tb_users.Find(id);
            if (tb_users == null)
            {
                return HttpNotFound();
            }
            return View(tb_users);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_users tb_users = db.tb_users.Find(id);
            db.tb_users.Remove(tb_users);
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
