using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyBanHang.Models;

namespace WebsiteQuanLyBanHang.Controllers
{
    public class NppPaymentCompanyController : Controller
    {
        private CSMSEntities db = new CSMSEntities();

        // GET: NppPaymentCompany
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Customer).Include(p => p.SalesMan);
            return View(payments.ToList());
        }

        // GET: NppPaymentCompany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: NppPaymentCompany/Create
        public ActionResult Create()
        {
            ViewBag.CustID = new SelectList(db.Customers, "CustID", "CustName");
            ViewBag.SalesPersonID = new SelectList(db.SalesMen, "SalesManID", "SalesManName");
            return View();
        }

        // POST: NppPaymentCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,PaymentNo,PaymentDate,PaymentAmt,CustID,SalesPersonID,Description")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustID = new SelectList(db.Customers, "CustID", "CustName", payment.CustID);
            ViewBag.SalesPersonID = new SelectList(db.SalesMen, "SalesManID", "SalesManName", payment.SalesPersonID);
            return View(payment);
        }

        // GET: NppPaymentCompany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustID = new SelectList(db.Customers, "CustID", "CustName", payment.CustID);
            ViewBag.SalesPersonID = new SelectList(db.SalesMen, "SalesManID", "SalesManName", payment.SalesPersonID);
            return View(payment);
        }

        // POST: NppPaymentCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,PaymentNo,PaymentDate,PaymentAmt,CustID,SalesPersonID,Description")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustID = new SelectList(db.Customers, "CustID", "CustName", payment.CustID);
            ViewBag.SalesPersonID = new SelectList(db.SalesMen, "SalesManID", "SalesManName", payment.SalesPersonID);
            return View(payment);
        }

        // GET: NppPaymentCompany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: NppPaymentCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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
