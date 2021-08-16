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
    public class NhaCCController : Controller
    {
        private Entities db = new Entities();

        // GET: NhaCC
        public async Task<ActionResult> Index()
        {
            return View(await db.NhaCCs.ToListAsync());
        }

        // GET: NhaCC/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCC nhaCC = await db.NhaCCs.FindAsync(id);
            if (nhaCC == null)
            {
                return HttpNotFound();
            }
            return View(nhaCC);
        }

        // GET: NhaCC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaCC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaNCC,TenNCC,DiaChi,EMail,SDT,Fax")] NhaCC nhaCC)
        {
            if (ModelState.IsValid)
            {
                db.NhaCCs.Add(nhaCC);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nhaCC);
        }

        // GET: NhaCC/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCC nhaCC = await db.NhaCCs.FindAsync(id);
            if (nhaCC == null)
            {
                return HttpNotFound();
            }
            return View(nhaCC);
        }

        // POST: NhaCC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaNCC,TenNCC,DiaChi,EMail,SDT,Fax")] NhaCC nhaCC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaCC).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nhaCC);
        }

        // GET: NhaCC/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCC nhaCC = await db.NhaCCs.FindAsync(id);
            if (nhaCC == null)
            {
                return HttpNotFound();
            }
            return View(nhaCC);
        }

        // POST: NhaCC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NhaCC nhaCC = await db.NhaCCs.FindAsync(id);
            db.NhaCCs.Remove(nhaCC);
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
