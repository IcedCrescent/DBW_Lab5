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
    public class HeadquartersController : Controller
    {
        private DataWarehouseEntities1 db = new DataWarehouseEntities1();

        // GET: Headquarters
        public ActionResult Index()
        {
            return View(db.Headquarters.ToList());
        }

        // GET: Headquarters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headquarter headquarter = db.Headquarters.Find(id);
            if (headquarter == null)
            {
                return HttpNotFound();
            }
            return View(headquarter);
        }

        // GET: Headquarters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Headquarters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "city_id,city_name,headquarter_address,state,time_start")] Headquarter headquarter)
        {
            if (ModelState.IsValid)
            {
                db.Headquarters.Add(headquarter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(headquarter);
        }

        // GET: Headquarters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headquarter headquarter = db.Headquarters.Find(id);
            if (headquarter == null)
            {
                return HttpNotFound();
            }
            return View(headquarter);
        }

        // POST: Headquarters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "city_id,city_name,headquarter_address,state,time_start")] Headquarter headquarter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(headquarter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(headquarter);
        }

        // GET: Headquarters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Headquarter headquarter = db.Headquarters.Find(id);
            if (headquarter == null)
            {
                return HttpNotFound();
            }
            return View(headquarter);
        }

        // POST: Headquarters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Headquarter headquarter = db.Headquarters.Find(id);
            db.Headquarters.Remove(headquarter);
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
