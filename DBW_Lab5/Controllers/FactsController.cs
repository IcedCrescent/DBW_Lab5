using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBW_Lab5.Models;

namespace DBW_Lab5.Controllers
{
    public class FactsController : Controller
    {
        private DataWarehouseEntities1 db = new DataWarehouseEntities1();

        // GET: Facts
        public ActionResult Index()
        {
            var facts = db.Facts.Include(f => f.Customer).Include(f => f.Headquarter).Include(f => f.Item).Include(f => f.Order).Include(f => f.Store).Include(f => f.Time);
            return View(facts.ToList());
        }

        // GET: Facts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fact fact = db.Facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            return View(fact);
        }

        // GET: Facts/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "name");
            ViewBag.city_id = new SelectList(db.Headquarters, "city_id", "city_name");
            ViewBag.item_id = new SelectList(db.Items, "item_id", "description");
            ViewBag.order_id = new SelectList(db.Orders, "order_id", "order_id");
            ViewBag.store_id = new SelectList(db.Stores, "store_id", "phone");
            ViewBag.time_id = new SelectList(db.Times, "time_id", "time_id");
            return View();
        }

        // POST: Facts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "time_id,city_id,store_id,customer_id,order_id,item_id,dollar_sold,avg_sales,stock_quantity,item_sold_quantity,num_orders")] Fact fact)
        {
            if (ModelState.IsValid)
            {
                db.Facts.Add(fact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "name", fact.customer_id);
            ViewBag.city_id = new SelectList(db.Headquarters, "city_id", "city_name", fact.city_id);
            ViewBag.item_id = new SelectList(db.Items, "item_id", "description", fact.item_id);
            ViewBag.order_id = new SelectList(db.Orders, "order_id", "order_id", fact.order_id);
            ViewBag.store_id = new SelectList(db.Stores, "store_id", "phone", fact.store_id);
            ViewBag.time_id = new SelectList(db.Times, "time_id", "time_id", fact.time_id);
            return View(fact);
        }

        // GET: Facts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fact fact = db.Facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "name", fact.customer_id);
            ViewBag.city_id = new SelectList(db.Headquarters, "city_id", "city_name", fact.city_id);
            ViewBag.item_id = new SelectList(db.Items, "item_id", "description", fact.item_id);
            ViewBag.order_id = new SelectList(db.Orders, "order_id", "order_id", fact.order_id);
            ViewBag.store_id = new SelectList(db.Stores, "store_id", "phone", fact.store_id);
            ViewBag.time_id = new SelectList(db.Times, "time_id", "time_id", fact.time_id);
            return View(fact);
        }

        // POST: Facts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "time_id,city_id,store_id,customer_id,order_id,item_id,dollar_sold,avg_sales,stock_quantity,item_sold_quantity,num_orders")] Fact fact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "name", fact.customer_id);
            ViewBag.city_id = new SelectList(db.Headquarters, "city_id", "city_name", fact.city_id);
            ViewBag.item_id = new SelectList(db.Items, "item_id", "description", fact.item_id);
            ViewBag.order_id = new SelectList(db.Orders, "order_id", "order_id", fact.order_id);
            ViewBag.store_id = new SelectList(db.Stores, "store_id", "phone", fact.store_id);
            ViewBag.time_id = new SelectList(db.Times, "time_id", "time_id", fact.time_id);
            return View(fact);
        }

        // GET: Facts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fact fact = db.Facts.Find(id);
            if (fact == null)
            {
                return HttpNotFound();
            }
            return View(fact);
        }

        // POST: Facts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fact fact = db.Facts.Find(id);
            db.Facts.Remove(fact);
            db.SaveChanges();
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
