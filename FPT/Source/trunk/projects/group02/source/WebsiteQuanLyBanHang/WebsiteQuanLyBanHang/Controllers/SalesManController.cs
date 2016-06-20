using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebsiteQuanLyBanHang.Models;
using PagedList;

namespace WebsiteQuanLyBanHang.Controllers
{
    public class SalesManController : Controller
    {
        private CSMSEntities db = new CSMSEntities();



        // GET: SalesMan
        public ActionResult Index(string searchName, string searchStatus, int? page)
        {
            if (searchName != null)
            {
                page = 1;
            }
            var salesMen = from s in db.SalesMen
                           select s;

            if (!String.IsNullOrEmpty(searchName))
            {
                salesMen = salesMen.Where(s => s.SalesManName.Contains(searchName));
            }
            if (!String.IsNullOrEmpty(searchStatus))
            {
                salesMen = salesMen.Where(s => s.Status.Contains(searchStatus));
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(salesMen.OrderBy(s => s.SalesManName).ToPagedList(pageNumber, pageSize));
        }

        // GET: SalesMan/Create
        public ActionResult Create()
        {
            SalesMan salesMan = new SalesMan();
            if (db.SalesMen.Count() == 0)
            {
                salesMan.SalesManID = "NV0001";
            }
            else
            {
                string str = db.SalesMen.ToList().Last().SalesManID.Substring(2);
                int id = int.Parse(str) + 1;
                string pre = "";
                if (id < 1000)
                {
                    pre = "NV0";
                }
                if (id < 100)
                {
                    pre = "NV00";
                }
                if (id < 10)
                {
                    pre = "NV000";
                }
                salesMan.SalesManID = pre + id.ToString();
            }

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "DE", Value = "DE" });
            items.Add(new SelectListItem { Text = "AV", Value = "AV" });
            items.Add(new SelectListItem { Text = "UA", Value = "UA" });
            ViewBag.Status = items;

            salesMan.OverAmt = 10000000;
            return PartialView(salesMan);
        }

        // POST: SalesMan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesManID,SalesManName,Address,OverAmt,Status,Description")] SalesMan salesMan)
        {
            if (ModelState.IsValid)
            {
                db.SalesMen.Add(salesMan);
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }

            return PartialView(salesMan);
        }

       
        // GET: SalesMan/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesMan salesMan = await db.SalesMen.FindAsync(id);
            if (salesMan == null)
            {
                return HttpNotFound();
            }
            return PartialView(salesMan);
        }

        // POST: SalesMan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesManID,SalesManName,Address,OverAmt,Status,Description")] SalesMan salesMan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesMan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Json(new { success = true });
            }
            return PartialView(salesMan);
        }

        // GET: SalesMan/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesMan salesMan = await db.SalesMen.FindAsync(id);
            if (salesMan == null)
            {
                return HttpNotFound();
            }
            return PartialView(salesMan);
        }

        // POST: SalesMan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            db.SalesMen.Find(id).Status="DE";
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
