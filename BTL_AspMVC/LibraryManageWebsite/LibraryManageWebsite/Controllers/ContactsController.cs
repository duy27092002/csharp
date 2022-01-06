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
    public class ContactsController : Controller
    {
        private ContactDAO contactDAO = new ContactDAO();

        // GET: Contacts
        [Authorize(Roles = "Admin, Nhân viên")]
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var ownerId = (string)Session["ownerId"];

            var getContactList = await contactDAO.GetByPaged(page, pageSize, keyword, ownerId);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(getContactList);
        }

        // GET: Contacts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OwnerId,AdminName,AdminPhone,AdminEmail,Status")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await contactDAO.Add(contact);

                TempData["AlertSuccessMessage"] = "Thêm liên hệ mới thành công!";

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Contact contact = await contactDAO.GetById(id);

            if (contact == null || Session["ownerId"] == null || (string)Session["ownerId"] != contact.OwnerId)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(contact);
        }

        // POST: Contacts/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OwnerId,AdminName,AdminPhone,AdminEmail,Status")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                await contactDAO.Update(contact);

                TempData["AlertSuccessMessage"] = "Cập nhật thông tin thành công!";

                return RedirectToAction("Index");
            }
            
            return View(contact);
        }

        // GET: Contacts/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            Contact contact = await contactDAO.GetById(id);

            if(contact == null || Session["ownerId"] == null || (string)Session["ownerId"] != contact.OwnerId)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await contactDAO.Delete(id);

            TempData["AlertSuccessMessage"] = "Xóa liên hệ thành công!";

            return RedirectToAction("Index");
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