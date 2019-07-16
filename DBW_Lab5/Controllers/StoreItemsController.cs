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
    public class StoreItemsController : Controller
    {
        private DataWarehouseEntities1 db = new DataWarehouseEntities1();

        // GET: StoreItems
        public ActionResult Index()
        {
            var storeItems = db.StoreItems.Include(s => s.Item).Include(s => s.Store);
            return View(storeItems.ToList());
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
