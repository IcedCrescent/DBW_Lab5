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
    public class OrdersController : Controller
    {
        private DataWarehouseEntities1 db = new DataWarehouseEntities1();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.OrderItem);
            return View(orders.ToList());
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
