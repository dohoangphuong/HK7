﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyBanHang.Models;
using PagedList;

namespace WebsiteQuanLyBanHang.Controllers
{
    public class CustomersController : Controller
    {
        private CSMSEntities db = new CSMSEntities();

        // GET: Customers
        public ActionResult Index(string searchName, string searchStatus, int? page)
        {

            if (searchName != null)
            {
                page = 1;
            }
            var Customers = from c in db.Customers
                           select c;
            if (!String.IsNullOrEmpty(searchName))
            {
                Customers = Customers.Where(s => s.CustName.Contains(searchName));
            }
            if (!String.IsNullOrEmpty(searchStatus))
            {
                Customers = Customers.Where(s => s.Status.Contains(searchStatus));
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(Customers.OrderBy(s => s.CustName).ToPagedList(pageNumber, pageSize));
        }


        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            if (db.Customers.Count() == 0)
            {
                customer.CustID = "KH0001";
            }
            else
            {
                string str = db.Customers.ToList().Last().CustID.Substring(2);
                int id = int.Parse(str) + 1;
                string pre = "";
                if (id < 1000)
                {
                    pre = "KH0";
                }
                if (id < 100)
                {
                    pre = "KH00";
                }
                if (id < 10)
                {
                    pre = "KH000";
                }

                customer.CustID = pre + id.ToString();
            }
            //Status
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "DE", Value = "DE" });
            items.Add(new SelectListItem { Text = "AV", Value = "AV" });
            items.Add(new SelectListItem { Text = "UA", Value = "UA" });
            ViewBag.Status = items;
            //Lấy những nhân viên hoạt động.
            var salesMen = from s in db.SalesMen
                           select s;
            salesMen = salesMen.Where(s => s.Status.Contains("AV"));
            //salesMen = salesMen.Where(s => s.Status.Contains("AV")).ToList();
            List<SelectListItem> nhanviens = new List<SelectListItem>();
            foreach (var nv in salesMen)
            {
                nhanviens.Add(new SelectListItem { Text = nv.SalesManID, Value = nv.SalesManID });
            }
            ViewBag.nhanvien = nhanviens;

            //customer.OverAmt = 10000000;
            return PartialView(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustID,CustName,Address,Phone,Fax,Email,Overdue,Amount,OverdueAmt,DueAmt,Status,Description,SalesManID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }

            return PartialView(customer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customers = await db.Customers.FindAsync(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return PartialView(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustID,CustName,Address,Phone,Fax,Email,Overdue,Amount,OverdueAmt,DueAmt,Status,Description,SalesManID")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return PartialView(customer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return PartialView(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return Json(new { success = true });
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
