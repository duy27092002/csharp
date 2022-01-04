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
    public class UsersController : Controller
    {
        private UserDAO userDAO = new UserDAO();

        [Authorize(Roles = "Admin")]
        // GET: Users
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var userList = await userDAO.GetByPaged(page, pageSize, keyword);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(userList);
        }

        // GET: Users/Details/5
        [Authorize(Roles = "Admin, Nhân viên, Developer")]
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await userDAO.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.UserId = BaseDAO.RandomString(10);
            return View();
        }

        // POST: Users/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,Birthday,Email,Phone,Address,Username,Password,UserType,OwnerId,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                await userDAO.Add(user);

                TempData["AlertSuccessMessage"] = "Thêm nhân viên mới thành công!";

                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "Admin, Nhân viên, Developer")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await userDAO.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            //ViewBag.OwnerId = new SelectList(db.Owners, "Id", "Name", user.OwnerId);
            return View(user);
        }

        // POST: Users/Edit/5
        [Authorize(Roles = "Admin, Nhân viên, Developer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,Birthday,Email,Phone,Address,Username,Password,UserType,OwnerId,Status")] User user)
        {
            if (ModelState.IsValid)
            {
                if (await userDAO.Update(user))
                {
                    if (user.UserType == 3)
                    {
                        TempData["AlertSuccessMessage"] = "Cập nhật thông tin tài khoản thành công!";

                        return RedirectToAction("Index", "Owners");
                    }
                    else if (user.UserType == 0)
                    {
                        TempData["AlertSuccessMessage"] = "Cập nhật thông tin thành công!";

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["AlertSuccessMessage"] = "Cập nhật thông tin tài khoản thành công!";

                        return RedirectToAction("Details", "Users", new { id = Session["userId"] });
                    }
                }
            }

            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await userDAO.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await userDAO.Delete(id);

            TempData["AlertSuccessMessage"] = "Xóa nhân viên thành công!";

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
