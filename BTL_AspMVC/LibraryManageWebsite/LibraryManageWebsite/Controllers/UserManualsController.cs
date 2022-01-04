using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryManageWebsite.Models.DAO;
using LibraryManageWebsite.Models.EF;

namespace LibraryManageWebsite.Controllers
{
    public class UserManualsController : Controller
    {
        private UserManualDAO umDAO = new UserManualDAO();

        // GET: UserManuals
        public async Task<ActionResult> Index()
        {
            return View(await umDAO.GetContent());
        }

        // GET: UserManuals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserManuals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UMContent")] UserManual userManual)
        {
            if (ModelState.IsValid)
            {
                await umDAO.Add(userManual);

                TempData["AlertSuccessMessage"] = "Tạo hướng dẫn thành công!";

                return RedirectToAction("Index");
            }

            return View(userManual);
        }

        // GET: UserManuals/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserManual userManual = await umDAO.GetById(id);
            if (userManual == null)
            {
                return HttpNotFound();
            }
            return View(userManual);
        }

        // POST: UserManuals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UMContent")] UserManual userManual)
        {
            if (ModelState.IsValid)
            {
                await umDAO.Update(userManual);

                TempData["AlertSuccessMessage"] = "Cập nhật hướng dẫn thành công!";

                return RedirectToAction("Index");
            }
            return View(userManual);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
