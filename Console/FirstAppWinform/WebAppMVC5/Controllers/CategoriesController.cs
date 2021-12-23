using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC5.Models.EF;
using PagedList;

namespace WebAppMVC5.Controllers
{
    public class CategoriesController : Controller
    {
        private T3H_K34DL1_DemoEntities db = new T3H_K34DL1_DemoEntities();

        // GET: Categories
        /*public async Task<ActionResult> Index(string keyword = "", int pageSize = 10, int pageNumber = 1)
        {
            List<Category> categories = new List<Category>();
            if (keyword != string.Empty)
            {
                categories = await db.Categories.Where(t => t.Name.Contains(keyword) || t.NameVN.Contains(keyword)).ToListAsync();
            }
            else
            {
                categories = await db.Categories.ToListAsync();
            }
            int pageCount = (int)(((categories.Count * 1.0) / pageSize) + 0.999999);
            pageCount = pageCount > 0 ? pageCount : 1;
            pageNumber = pageNumber <= pageCount ? pageNumber : pageCount;
            categories = categories.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.Keyword = keyword;
            ViewBag.PageCount = pageCount;
            ViewBag.PageSize = pageSize;
            ViewBag.PageNumber = pageNumber;
            return View(categories);
        }*/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetViewTableInfo(string keyword = "", int pageSize = 10, int pageNumber = 1)
        {
            var categories = db.Categories.Where(t => t.Name.Contains(keyword) || t.NameVN.Contains(keyword))
                .OrderBy(t => t.ID).ToPagedList(pageNumber, pageSize);
            return PartialView(categories);
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,NameVN")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,NameVN")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
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
