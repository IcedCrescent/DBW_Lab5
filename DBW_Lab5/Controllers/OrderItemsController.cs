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
    public class OrderItemsController : Controller
    {
        private DataWarehouseEntities1 db = new DataWarehouseEntities1();

        // GET: OrderItems
        public ActionResult Index()
        {
            var orderItems = db.OrderItems.Include(o => o.Item).Include(o => o.Order);
            return View(orderItems.ToList());
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
