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

        string userId = BaseDAO.RandomString(10);

        [Authorize(Roles = "Admin")]
        // GET: Users
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var ownerId = (string)Session["ownerId"];

            var userList = await userDAO.GetByPaged(page, pageSize, keyword, ownerId);

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
                return RedirectToAction("Error", "Home");
            }

            User user = await userDAO.GetById(id);

            if (User.IsInRole("Admin"))
            {
                if (user == null || Session["ownerId"] == null || user.OwnerId != (string)Session["ownerId"])
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                if (user == null || Session["userId"] == null || user.Id != (string)Session["userId"])
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            return View(user);
        }

        // GET: Users/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,Birthday,Email,Phone,Address,Username,Password,UserType,OwnerId,Status")] User user)
        {
            user.Id = userId;

            if (ModelState.IsValid)
            {
                if (userDAO.CheckUsername(user.Username) == false)
                {
                    TempData["AlertErrorMessage"] = "Tên đăng nhập này đã tồi tại. Xin hãy đổi lại!";
                }
                else if (userDAO.CheckEmail(user.Email) == false)
                {
                    TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại email!";
                }
                else if (userDAO.CheckPhone(user.Phone) == false)
                {
                    TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại số điện thoại!";
                }
                else
                {
                    if (await userDAO.Add(user))
                    {
                        TempData["AlertSuccessMessage"] = "Thêm nhân viên mới thành công!";

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["AlertErrorMessage"] = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                        return View(user);
                    }
                }
            }

            return View(user);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "Admin, Nhân viên, Developer")]
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }

            User user = await userDAO.GetById(id);

            if (User.IsInRole("Admin"))
            {
                if (user == null || Session["ownerId"] == null || user.OwnerId != (string)Session["ownerId"])
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            else
            {
                if (user == null || Session["userId"] == null || user.Id != (string)Session["userId"])
                {
                    return RedirectToAction("Error", "Home");
                }
            }

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
                var getUserFromDB = await userDAO.GetById(user.Id);

                if (getUserFromDB.Email != user.Email)
                {
                    if (userDAO.CheckEmail(user.Email) == false)
                    {
                        TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại email!";

                        return View(user);
                    }
                }
                else if (getUserFromDB.Phone != user.Phone)
                {
                    if (userDAO.CheckPhone(user.Phone) == false)
                    {
                        TempData["AlertErrorMessage"] = "Vui lòng kiểm tra lại số điện thoại!";

                        return View(user);
                    }
                }

                if (await userDAO.Update(user))
                {
                    TempData["AlertSuccessMessage"] = "Cập nhật thông tin tài khoản thành công!";

                    return RedirectToAction("Details", "Users", new { id = user.Id });
                }
                else
                {
                    TempData["AlertErrorMessage"] = "Đã có sự cố xảy ra. Vui lòng thử lại!";

                    return View(user);
                }
            }

            return View(user);
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