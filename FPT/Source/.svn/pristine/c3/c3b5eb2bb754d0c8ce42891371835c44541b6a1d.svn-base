using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Query.Dynamic;
using System.Web.Services.Description;
using WebsiteQuanLyBanHang.Models;
using PagedList;
namespace WebsiteQuanLyBanHang.Controllers
{
    public class SalesOrdersController : Controller
    {
        private CSMSEntities db = new CSMSEntities();

        // GET: SalesOrders
        public ActionResult Index()
        {
            var salesOrders = db.SalesOrders.Include(s => s.Customer).Include(s => s.User).Include(s => s.InvoiceType1).Include(s => s.User1).OrderByDescending(s => s.OrderNo);

            ViewBag.InvoiceType = new SelectList(db.InvoiceTypes, "InvoiceType1", "TypeName");

            return View(salesOrders.ToPagedList(1, 1));
        }
        [HttpGet]
        public ActionResult Index(string invoiceType, int? page, string searchString)
        {
            var salesOrders = db.SalesOrders.Include(s => s.Customer).Include(s => s.User).Include(s => s.InvoiceType1).Include(s => s.User1).OrderByDescending(s => s.OrderNo);

            ViewBag.InvoiceType = new SelectList(db.InvoiceTypes, "InvoiceType1", "TypeName", invoiceType);

            if (!string.IsNullOrEmpty(invoiceType))
            {
                salesOrders = salesOrders.Where(s => s.InvoiceType == invoiceType).OrderByDescending(s => s.OrderNo);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                DateTime dt;
                if (DateTime.TryParse(searchString, out dt))
                {
                    salesOrders = salesOrders.Where(s => s.OrderDate.Equals(dt) ||
                        s.OverdueDate.Equals(dt)).OrderByDescending(s => s.OrderNo);
                }
                else
                {
                    salesOrders = salesOrders.Where(s => s.OrderNo.Contains(searchString) ||
                                                     s.UserID.Contains(searchString) ||
                                                     s.CustID.Contains(searchString)
                    ).OrderByDescending(s => s.OrderNo);
                }

            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(salesOrders.ToPagedList(pageNumber, pageSize));
        }

        // GET: SalesOrders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return PartialView(salesOrder);
        }

        // GET: SalesOrders/Create
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Customers, "CustID", "CustName");
            ViewBag.UserID = new SelectList(db.Users, "UserName", "UserName");
            ViewBag.InvoiceType = new SelectList(db.InvoiceTypes, "InvoiceType1", "InvoiceType1");
            ViewBag.UserIDRec = new SelectList(db.Users, "UserName", "UserName");
            return PartialView();
        }

        // POST: SalesOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderNo,OrderDate,InvoiceType,UserID,UserIDRec,CustID,OverdueDate,OrderDisc,TaxAmt,TotalAmt,Payment,Debt,Description")] SalesOrder salesOrder)
        {
            if (db.SalesOrders.Any(n => n.OrderNo == salesOrder.OrderNo))
            {
                ModelState.AddModelError("OrderNo", String.Format("{0} already exist.", salesOrder.OrderNo));
            }
            if (salesOrder.OrderDate > DateTime.Now)
            {
                ModelState.AddModelError("OrderDate", "Order Date must be greater than the current date.");
            }
            if (salesOrder.OverdueDate < salesOrder.OrderDate)
            {
                ModelState.AddModelError("OverdueDate", "Over Due Date must be greater than the Order Date.");
            }
            if (ModelState.IsValid && !db.SalesOrders.Any(n => n.OrderNo == salesOrder.OrderNo))
            {

                db.SalesOrders.Add(salesOrder);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.CustID = new SelectList(db.Customers, "CustID", "CustName", salesOrder.CustID);
            ViewBag.UserID = new SelectList(db.Users, "UserName", "UserName", salesOrder.UserID);
            ViewBag.InvoiceType = new SelectList(db.InvoiceTypes, "InvoiceType1", "InvoiceType1", salesOrder.InvoiceType);
            ViewBag.UserIDRec = new SelectList(db.Users, "UserName", "UserName", salesOrder.UserIDRec);
            return PartialView(salesOrder);
        }

        public ActionResult AddDetails(string id)
        {
            SlsOrderDetail slsOrderDetail = new SlsOrderDetail();
            slsOrderDetail.OrderNo = id;
            ViewBag.InvtID = new SelectList(db.Inventories, "InvtID", "InvtName", slsOrderDetail.InvtID);
            ViewBag.OrderNo = new SelectList(db.SalesOrders, "OrderNo", "OrderNo", slsOrderDetail.OrderNo);
            return PartialView(slsOrderDetail);
        }

        // POST: SlsOrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDetails([Bind(Include = "ID,OrderNo,InvtID,Qty,SalesPrice,Discount,TaxAmt,Amount")] SlsOrderDetail slsOrderDetail)
        {
            if (db.SlsOrderDetails.Any(n => n.ID == slsOrderDetail.ID))
            {
                ModelState.AddModelError("ID", String.Format("{0} already exist.", slsOrderDetail.ID));
            }

            if (ModelState.IsValid && !db.SlsOrderDetails.Any(n => n.ID == slsOrderDetail.ID))
            {
                db.SlsOrderDetails.Add(slsOrderDetail);
                db.SaveChanges();
                return Json(new { success = true });
            }

            ViewBag.InvtID = new SelectList(db.Inventories, "InvtID", "InvtName", slsOrderDetail.InvtID);
            ViewBag.OrderNo = new SelectList(db.SalesOrders, "OrderNo", "OrderNo", slsOrderDetail.OrderNo);
            return PartialView(slsOrderDetail);
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
