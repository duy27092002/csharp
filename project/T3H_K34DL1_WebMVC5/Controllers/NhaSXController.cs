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
    public class NhaSXController : Controller
    {
        private Entities db = new Entities();

        // GET: NhaSX
        public async Task<ActionResult> Index()
        {
            return View(await db.NhaSXes.ToListAsync());
        }

        // GET: NhaSX/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaSX nhaSX = await db.NhaSXes.FindAsync(id);
            if (nhaSX == null)
            {
                return HttpNotFound();
            }
            return View(nhaSX);
        }

        // GET: NhaSX/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhaSX/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaNSX,TenNSX,DiaChi,EMail,SDT,Fax")] NhaSX nhaSX)
        {
            if (ModelState.IsValid)
            {
                db.NhaSXes.Add(nhaSX);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(nhaSX);
        }

        // GET: NhaSX/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaSX nhaSX = await db.NhaSXes.FindAsync(id);
            if (nhaSX == null)
            {
                return HttpNotFound();
            }
            return View(nhaSX);
        }

        // POST: NhaSX/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaNSX,TenNSX,DiaChi,EMail,SDT,Fax")] NhaSX nhaSX)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaSX).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nhaSX);
        }

        // GET: NhaSX/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaSX nhaSX = await db.NhaSXes.FindAsync(id);
            if (nhaSX == null)
            {
                return HttpNotFound();
            }
            return View(nhaSX);
        }

        // POST: NhaSX/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            NhaSX nhaSX = await db.NhaSXes.FindAsync(id);
            db.NhaSXes.Remove(nhaSX);
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
