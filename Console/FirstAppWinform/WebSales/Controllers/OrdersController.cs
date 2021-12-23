using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSales.Models.EF;
using WebSales.Models.DAO;

namespace WebSales.Controllers
{
    public class OrdersController : BaseController
    {
        private OrderDAO dao = new OrderDAO();

        // GET: Orders
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10, string keyword = "")
        {
            var model = await dao.GetByPaged(page, pageSize, keyword);

            ViewBag.Keyword = keyword;
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;

            return View(model);
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await dao.GetSingleByID((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public async Task<ActionResult> Create()
        {
            var model = new Order()
            {
                OrderDate = DateTime.Now
            };
            ViewBag.CustomerId = new SelectList(await new CustomerDAO().GetAll(), "ID", "Fullname");
            return View(model);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CustomerId,OrderDate,Address,Amount,Description")] Order order)
        {
            if (ModelState.IsValid)
            {
                await dao.Add(order);
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(await new CustomerDAO().GetAll(), "ID", "Fullname", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await dao.GetSingleByID((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(await new CustomerDAO().GetAll(), "ID", "Fullname", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CustomerId,OrderDate,Address,Amount,Description")] Order order)
        {
            if (ModelState.IsValid)
            {
                await dao.Update(order);
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(await new CustomerDAO().GetAll(), "ID", "Fullname", order.CustomerId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await dao.GetSingleByID((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (await dao.Delete(id))
            {
                return RedirectToAction("Index");
            }

            Order order = await dao.GetSingleByID((int)id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
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
