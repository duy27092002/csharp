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
using Newtonsoft.Json;

namespace T3H_K34DL1_WebMVC5.Controllers
{
    public class HoaDonXuatController : Controller
    {
        private Entities db = new Entities();

        // GET: HoaDonXuat
        public async Task<ActionResult> Index()
        {
            var hoaDonXuats = db.HoaDonXuats.Include(h => h.KhachHang);
            return View(await hoaDonXuats.OrderByDescending(t => t.NgayXuat).ToListAsync());
        }

        // GET: HoaDonXuat/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoaDonXuat = await db.HoaDonXuats.FindAsync(id);
            if (hoaDonXuat == null)
            {
                return HttpNotFound();
            }

            ViewData["CT_HoaDonXuat"] = await db.CT_HDXuat.Where(t => t.MaHDXuat == id).ToListAsync();

            return View(hoaDonXuat);
        }

        // GET: HoaDonXuat/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            ViewBag.LoaiSanPham = new SelectList(db.LoaiGiays, "MaLG", "TenLG");
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            return View();
        }

        // POST: HoaDonXuat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaHDXuat,NgayXuat,MaKH,TongTien")] HoaDonXuat hoaDonXuat)
        {
            if (ModelState.IsValid)
            {
                if (hoaDonXuat.MaKH != null)
                {
                    hoaDonXuat.TongTien = 0;
                    db.HoaDonXuats.Add(hoaDonXuat);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                /*db.HoaDonXuats.Add(hoaDonXuat);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");*/
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", hoaDonXuat.MaKH);
            return View(hoaDonXuat);
        }

        // GET: HoaDonXuat/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoaDonXuat = await db.HoaDonXuats.FindAsync(id);
            if (hoaDonXuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", hoaDonXuat.MaKH);
            ViewData["CT_HoaDonXuat"] = await db.CT_HDXuat.Where(t => t.MaHDXuat == id).ToListAsync();
            return View(hoaDonXuat);
        }

        // POST: HoaDonXuat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaHDXuat,NgayXuat,MaKH,TongTien")] HoaDonXuat hoaDonXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonXuat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", hoaDonXuat.MaKH);
            return View(hoaDonXuat);
        }

        // GET: HoaDonXuat/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoaDonXuat = await db.HoaDonXuats.FindAsync(id);
            if (hoaDonXuat == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonXuat);
        }

        // POST: HoaDonXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HoaDonXuat hoaDonXuat = await db.HoaDonXuats.FindAsync(id);

            var cT_HDXuats = await db.CT_HDXuat.Where(t => t.MaHDXuat == id).ToListAsync();

            await UpdateCount(cT_HDXuats, -1);

            db.CT_HDXuat.RemoveRange(cT_HDXuats);

            db.HoaDonXuats.Remove(hoaDonXuat);
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

        [HttpPost]
        public async Task<JsonResult> CreateConfirmed(HoaDonXuat info, string json)
        {
            string msg = "OK";

            List<CT_HDXuat> cT_HDXuats = JsonConvert.DeserializeObject<List<CT_HDXuat>>(json);

            try
            {
                //Lấy giá tiền
                var maGiays = cT_HDXuats.Select(t => t.MaGiay).ToArray();
                var giays = await db.Giays.Where(t => maGiays.Contains(t.MaGiay)).ToArrayAsync();

                foreach (var giay in giays)
                {
                    var cT_HDXuat = cT_HDXuats.Where(t => t.MaGiay == giay.MaGiay).FirstOrDefault();

                    cT_HDXuat.Gia = giay.Gia;
                }

                info.TongTien = cT_HDXuats.Select(t => (decimal)t.SoLuong * t.Gia).Sum();

                db.HoaDonXuats.Add(info);

                await db.SaveChangesAsync();

                foreach (var cT_HDXuat in cT_HDXuats)
                {
                    cT_HDXuat.MaHDXuat = info.MaHDXuat;
                }

                db.CT_HDXuat.AddRange(cT_HDXuats);

                await UpdateCount(cT_HDXuats, -1);

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                msg = "Fail";
            }

            return Json(new { msg = msg });
        }

        private async Task UpdateCount(List<CT_HDXuat> cT_HDXuats, int type)
        {
            var maGiays = cT_HDXuats.Select(t => t.MaGiay).ToArray();

            var giays = await db.Giays.Where(t => maGiays.Contains(t.MaGiay)).ToListAsync();

            foreach (var giay in giays)
            {
                var count = cT_HDXuats.Where(t => t.MaGiay == giay.MaGiay).FirstOrDefault().SoLuong;

                giay.SoLuong += count * type;
            }

            await db.SaveChangesAsync();
        }
    }
}
