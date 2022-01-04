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
    public class RegulationsController : Controller
    {
        private RegulationDAO regulationDAO = new RegulationDAO();

        // GET: Regulations
        public async Task<ActionResult> Index()
        {
            return View(await regulationDAO.GetContent());
        }

        // GET: Regulations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regulations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RegulationsContent,OwnerId")] Regulation regulation)
        {
            if (ModelState.IsValid)
            {
                var checkOwnerId = await regulationDAO.CheckOwnerId(regulation.OwnerId);

                if (checkOwnerId)
                {
                    await regulationDAO.Add(regulation);

                    TempData["AlertSuccessMessage"] = "Tạo quy định thành công!";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["AlertErrorMessage"] = "Mã xác minh không hợp lệ";
                }
            }

            return View(regulation);
        }

        // GET: Regulations/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regulation regulation = await regulationDAO.GetById(id);
            if (regulation == null)
            {
                return HttpNotFound();
            }
            
            return View(regulation);
        }

        // POST: Regulations/Edit/5
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
