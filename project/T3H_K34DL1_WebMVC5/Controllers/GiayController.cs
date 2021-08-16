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

namespace T3H_K34DL1_WebMVC5.Controllers
{
    public class GiayController : Controller
    {
        private Entities db = new Entities();

        // GET: Giay
        public async Task<ActionResult> Index()
        {
            var giays = db.Giays.Include(g => g.LoaiGiay).Include(g => g.NhaSX);
            return View(await giays.ToListAsync());
        }

        // GET: Giay/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = await db.Giays.FindAsync(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            return View(giay);
        }

        // GET: Giay/Create
        public ActionResult Create()
        {
            Giay giay = new Giay();
            ViewBag.MaLG = new SelectList(db.LoaiGiays, "MaLG", "TenLG");
            ViewBag.MaNSX = new SelectList(db.NhaSXes, "MaNSX", "TenNSX");
            return View(giay);
        }

        // POST: Giay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaGiay,TenGiay,MaNSX,MaLG,SoLuong,KichCo,MauSac,Gia,HinhAnh")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                db.Giays.Add(giay);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MaLG = new SelectList(db.LoaiGiays, "MaLG", "TenLG", giay.MaLG);
            ViewBag.MaNSX = new SelectList(db.NhaSXes, "MaNSX", "TenNSX", giay.MaNSX);
            return View(giay);
        }

        // GET: Giay/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = await db.Giays.FindAsync(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLG = new SelectList(db.LoaiGiays, "MaLG", "TenLG", giay.MaLG);
            ViewBag.MaNSX = new SelectList(db.NhaSXes, "MaNSX", "TenNSX", giay.MaNSX);
            return View(giay);
        }

        // POST: Giay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaGiay,TenGiay,MaNSX,MaLG,SoLuong,KichCo,MauSac,Gia,HinhAnh")] Giay giay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giay).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MaLG = new SelectList(db.LoaiGiays, "MaLG", "TenLG", giay.MaLG);
            ViewBag.MaNSX = new SelectList(db.NhaSXes, "MaNSX", "TenNSX", giay.MaNSX);
            return View(giay);
        }

        // GET: Giay/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giay giay = await db.Giays.FindAsync(id);
            if (giay == null)
            {
                return HttpNotFound();
            }
            return View(giay);
        }

        // POST: Giay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Giay giay = await db.Giays.FindAsync(id);
            db.Giays.Remove(giay);
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

        [HttpGet]
        public async Task<JsonResult> GetAnother(string json, int malg)
        {
            json = json.Replace("[", "").Replace("]", "");
            int[] ids = json == string.Empty ? new int[0] : json.Split(',').Select(t => int.Parse(t)).ToArray();
            var models = await db.Giays.Where(t => !ids.Contains(t.MaGiay) && t.MaLG == malg).ToArrayAsync();
            return Json(new
            {
                data = models.Select(t => new
                {
                    id = t.MaGiay,
                    name = t.TenGiay,
                    producer = t.NhaSX.TenNSX,
                    count = t.SoLuong,
                    unitPrice = t.Gia
                }).ToArray()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
