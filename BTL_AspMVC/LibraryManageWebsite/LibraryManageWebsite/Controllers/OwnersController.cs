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
    [Authorize(Roles = "Developer")]
    public class OwnersController : Controller
    {
        private OwnerDAO ownerDAO = new OwnerDAO();
        private UserDAO userDAO = new UserDAO();

        string ownerId = BaseDAO.RandomString(10);
        string userId = BaseDAO.RandomString(10);

        // GET: Owners
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var getList = await ownerDAO.GetByPaged(page, pageSize, keyword);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(getList);
        }

        // GET: Owners/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = await ownerDAO.GetById(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,Phone,RegistrationTime,ExpireTime,Status")] Owner owner)
        {
            owner.Id = ownerId;

            if (ModelState.IsValid)
            {
                await ownerDAO.Add(owner);

                TempData["AlertSuccessMessage"] = "Thêm người mua mới thành công!";

                return RedirectToAction("Index");
            }

            return View(owner);
        }

        // GET: Owners/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Owner owner = await ownerDAO.GetById(id);
            if (owner == null)
            {
                return HttpNotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email,Phone,RegistrationTime,ExpireTime,Status")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                await ownerDAO.Update(owner);

                TempData["AlertSuccessMessage"] = "Cập nhật thông tin thành công!";

                return RedirectToAction("Index");
            }
            return View(owner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

        // mở view thêm admin cho khách hàng
        public async Task<ActionResult> AddNewAdmin(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Owner owner = await ownerDAO.GetById(id);

            if (owner == null)
            {
                return HttpNotFound();
            }

            Session["OwnerIdToAddAdmin"]  = owner.Id;

            return View();
        }

        // tiến hành thêm admin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewAdmin([Bind(Include = "Id,Name,Gender,Birthday,Email,Phone,Address,Username,Password,UserType,OwnerId,Status")] User user)
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

        public async Task<ActionResult> AdminList(string id, int page = 1, int pageSize = 10, string keyword = "")
        {
            var getAdminListByOwnerId = await userDAO.GetAdminListByPaged(page, pageSize, keyword, id);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(getAdminListByOwnerId);
        }
    }
}
