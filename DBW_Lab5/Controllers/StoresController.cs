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
    public class StoresController : Controller
    {
        private DataWarehouseEntities1 db = new DataWarehouseEntities1();

        // GET: Stores
        public ActionResult Index()
        {
            var stores = db.Stores.Include(s => s.Headquarter).Include(s => s.StoreItem);
            return View(stores.ToList());
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
