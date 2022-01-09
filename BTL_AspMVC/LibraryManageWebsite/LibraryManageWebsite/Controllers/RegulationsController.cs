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
    [Authorize]
    public class RegulationsController : Controller
    {
        private RegulationDAO regulationDAO = new RegulationDAO();

        // GET: Regulations
        [Authorize(Roles = "Admin, Nhân viên")]
        public async Task<ActionResult> Index()
        {
            ViewBag.IsExited = regulationDAO.IsExited((string)Session["ownerId"]);

            return View(await regulationDAO.GetContent((string)Session["ownerId"]));
        }

        // GET: Regulations/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regulations/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RegulationsContent,OwnerId")] Regulation regulation)
        {
            if (ModelState.IsValid)
            {
                await regulationDAO.Add(regulation);

                TempData["AlertSuccessMessage"] = "Tạo quy định thành công!";

                return RedirectToAction("Index");
            }

            return View(regulation);
        }

        // GET: Regulations/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Regulation regulation = await regulationDAO.GetById(id);

            if (regulation == null || Session["ownerId"] == null || (string)Session["ownerId"] != regulation.OwnerId)
            {
                return RedirectToAction("Error", "Home");
            }
            
            return View(regulation);
        }

        // POST: Regulations/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RegulationsContent,OwnerId")] Regulation regulation)
        {
            if (ModelState.IsValid)
            {
                await regulationDAO.Update(regulation);

                TempData["AlertSuccessMessage"] = "Cập nhật quy định thành công!";

                return RedirectToAction("Index");
            }
            
            return View(regulation);
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
