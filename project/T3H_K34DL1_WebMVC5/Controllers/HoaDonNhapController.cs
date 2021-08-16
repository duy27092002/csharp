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
    public class HoaDonNhapController : Controller
    {
        private Entities db = new Entities();

        // GET: HoaDonNhap
        public async Task<ActionResult> Index()
        {
            var hoaDonNhaps = db.HoaDonNhaps.Include(h => h.NhaCC).Include(h => h.NhanVien);
            return View(await hoaDonNhaps.OrderByDescending(t => t.NgayNhap).ToListAsync());
        }

        // GET: HoaDonNhap/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = await db.HoaDonNhaps.FindAsync(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }

            ViewData["CT_HoaDonNhap"] = await db.CT_HDNhap.Where(t => t.MaHDNhap == id).ToListAsync();

            return View(hoaDonNhap);
        }

        // GET: HoaDonNhap/Create
        public ActionResult Create()
        {
            /*HoaDonNhap model = new HoaDonNhap()
            {
                NgayNhap = DateTime.Now,
            };
            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            return View(model);*/

            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV");
            ViewBag.LoaiSanPham = new SelectList(db.LoaiGiays, "MaLG", "TenLG");
            return View();
        }

        // POST: HoaDonNhap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaHDNhap,NgayNhap,MaNV,TongTien,MaNCC")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                if (hoaDonNhap.MaNCC != null && hoaDonNhap.MaNV != null)
                {
                    hoaDonNhap.TongTien = 0;
                    db.HoaDonNhaps.Add(hoaDonNhap);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", hoaDonNhap.MaNV);
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhap/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = await db.HoaDonNhaps.FindAsync(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", hoaDonNhap.MaNV);
            ViewData["CT_HoaDonNhap"] = await db.CT_HDNhap.Where(t => t.MaHDNhap == id).ToListAsync();
            return View(hoaDonNhap);
        }

        // POST: HoaDonNhap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaHDNhap,NgayNhap,MaNV,TongTien,MaNCC")] HoaDonNhap hoaDonNhap)
        {
            if (ModelState.IsValid)
            {
                /*if (hoaDonNhap.MaNCC != null && hoaDonNhap.MaNV != null)
                {
                    hoaDonNhap.TongTien = 0;
                    db.Entry(hoaDonNhap).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }*/

                db.Entry(hoaDonNhap).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCCs, "MaNCC", "TenNCC", hoaDonNhap.MaNCC);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "TenNV", hoaDonNhap.MaNV);
            return View(hoaDonNhap);
        }

        // GET: HoaDonNhap/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonNhap hoaDonNhap = await db.HoaDonNhaps.FindAsync(id);
            if (hoaDonNhap == null)
            {
                return HttpNotFound();
            }

            return View(hoaDonNhap);
        }

        // POST: HoaDonNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HoaDonNhap hoaDonNhap = await db.HoaDonNhaps.FindAsync(id);

            var cT_HDNhaps = await db.CT_HDNhap.Where(t => t.MaHDNhap == id).ToListAsync();

            await UpdateCount(cT_HDNhaps, -1);

            db.CT_HDNhap.RemoveRange(cT_HDNhaps);

            db.HoaDonNhaps.Remove(hoaDonNhap);
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
        public async Task<JsonResult> CreateConfirmed(HoaDonNhap info, string json)
        {
            string msg = "OK";

            List<CT_HDNhap> cT_HDNhaps = JsonConvert.DeserializeObject<List<CT_HDNhap>>(json);

            try
            {
                info.TongTien = cT_HDNhaps.Select(t => (decimal)t.SoLuong * t.Gia).Sum();

                db.HoaDonNhaps.Add(info);

                await db.SaveChangesAsync();

                foreach (var cT_HDNhap in cT_HDNhaps)
                {
                    cT_HDNhap.MaHDNhap = info.MaHDNhap;
                }

                db.CT_HDNhap.AddRange(cT_HDNhaps);

                await UpdateCount(cT_HDNhaps, 1);

                await db.SaveChangesAsync();
            } catch(Exception ex)
            {
                msg = "Fail";
            }

            return Json(new { msg = msg });
        }

        private async Task UpdateCount(List<CT_HDNhap> cT_HDNhaps, int type)
        {
            var maGiays = cT_HDNhaps.Select(t => t.MaGiay).ToArray();

            var giays = await db.Giays.Where(t => maGiays.Contains(t.MaGiay)).ToListAsync();

            foreach (var giay in giays)
            {
                var count = cT_HDNhaps.Where(t => t.MaGiay == giay.MaGiay).FirstOrDefault().SoLuong;

                giay.SoLuong += count * type;
            }

            await db.SaveChangesAsync();
        }
    }
}
