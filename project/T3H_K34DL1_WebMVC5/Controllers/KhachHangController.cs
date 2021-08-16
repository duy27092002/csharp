using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using T3H_K34DL1_WebMVC5.Models.EF;
using T3H_K34DL1_WebMVC5.Models;
using PagedList;

namespace T3H_K34DL1_WebMVC5.Controllers
{
    public class KhachHangController : Controller
    {
        private Entities db = new Entities();

        // GET: KhachHang
        /*public async Task<ActionResult> Index()
        {
            KhachHangModel model = new KhachHangModel();
            ViewBag.Count = model.GetCount();
            return View(await db.KhachHangs.ToListAsync());
        }*/

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            // lấy tham số sắp xếp theo cái gì (tên hay ngày sinh)
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BirthdaySortParm = sortOrder == "birthday" ? "birthday_desc" : "birthday";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            // truy vấn danh sách khách hàng trong db
            var khachHangs = from s in db.KhachHangs
                           select s;

            // nếu có chuỗi tìm kiếm thì tiến hành tìm kiếm theo TenKH
            // nếu chuỗi rỗng thì trả lại danh sách ban đầu
            if (!String.IsNullOrEmpty(searchString))
            {
                khachHangs = khachHangs.Where(s => s.TenKH.Contains(searchString));
            }

            // các trường hợp sắp xếp thứ tự 
            switch (sortOrder)
            {
                case "name_desc":
                    khachHangs = khachHangs.OrderByDescending(s => s.TenKH);
                    break;
                case "birthday":
                    khachHangs = khachHangs.OrderBy(s => s.NgaySinh);
                    break;
                case "birthday_desc":
                    khachHangs = khachHangs.OrderByDescending(s => s.NgaySinh);
                    break;
                default:
                    khachHangs = khachHangs.OrderBy(s => s.TenKH);
                    break;
            }
            int pageSize = 3; // số lượng khách hàng trên 1 trang
            int pageNumber = (page ?? 1); // nếu có giá trị của page thì lấy số đó, còn nếu null hoặc rỗng thì trả page = 1
            return View(khachHangs.ToPagedList(pageNumber, pageSize));
        }

        // GET: KhachHang/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = await db.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHang/Create
        public ActionResult Create()
        {
            var model = new KhachHang();
            return View(model);
        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaKH,TenKH,GioiTinh,NgaySinh,DiaChi,SDT")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: KhachHang/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = await db.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaKH,TenKH,GioiTinh,NgaySinh,DiaChi,SDT")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: KhachHang/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = await db.KhachHangs.FindAsync(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            KhachHang khachHang = await db.KhachHangs.FindAsync(id);
            db.KhachHangs.Remove(khachHang);
            await db.SaveChangesAsync();
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
