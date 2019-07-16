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
    public class MailOrderCustomersController : Controller
    {
        private DataWarehouseEntities1 db = new DataWarehouseEntities1();

        // GET: MailOrderCustomers
        public ActionResult Index()
        {
            var mailOrderCustomers = db.MailOrderCustomers.Include(m => m.Customer);
            return View(mailOrderCustomers.ToList());
        }

        // GET: MailOrderCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailOrderCustomer mailOrderCustomer = db.MailOrderCustomers.Find(id);
            if (mailOrderCustomer == null)
            {
                return HttpNotFound();
            }
            return View(mailOrderCustomer);
        }

        // GET: MailOrderCustomers/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "name");
            return View();
        }

        // POST: MailOrderCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_id,post_address,time_order")] MailOrderCustomer mailOrderCustomer)
        {
            if (ModelState.IsValid)
            {
                db.MailOrderCustomers.Add(mailOrderCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "name", mailOrderCustomer.customer_id);
            return View(mailOrderCustomer);
        }

        // GET: MailOrderCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailOrderCustomer mailOrderCustomer = db.MailOrderCustomers.Find(id);
            if (mailOrderCustomer == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "name", mailOrderCustomer.customer_id);
            return View(mailOrderCustomer);
        }

        // POST: MailOrderCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_id,post_address,time_order")] MailOrderCustomer mailOrderCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mailOrderCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.Customers, "customer_id", "name", mailOrderCustomer.customer_id);
            return View(mailOrderCustomer);
        }

        // GET: MailOrderCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MailOrderCustomer mailOrderCustomer = db.MailOrderCustomers.Find(id);
            if (mailOrderCustomer == null)
            {
                return HttpNotFound();
            }
            return View(mailOrderCustomer);
        }

        // POST: MailOrderCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MailOrderCustomer mailOrderCustomer = db.MailOrderCustomers.Find(id);
            db.MailOrderCustomers.Remove(mailOrderCustomer);
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
