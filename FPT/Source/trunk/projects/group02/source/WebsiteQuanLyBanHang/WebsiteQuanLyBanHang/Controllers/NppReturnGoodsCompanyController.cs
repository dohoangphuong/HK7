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
    public class NppReturnGoodsCompanyController : Controller
    {
        private CSMSEntities db = new CSMSEntities();

        // GET: NppReturnGoodsCompany
        public ActionResult Index()
        {
            var returnGoods = db.ReturnGoods.Include(r => r.SalesMan).Include(r => r.User);
            return View(returnGoods.ToList());
        }

        // GET: NppReturnGoodsCompany/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnGood returnGood = db.ReturnGoods.Find(id);
            if (returnGood == null)
            {
                return HttpNotFound();
            }
            return View(returnGood);
        }

        // GET: NppReturnGoodsCompany/Create
        public ActionResult Create()
        {
            ViewBag.SaleManID = new SelectList(db.SalesMen, "SalesManID", "SalesManName");
            ViewBag.IDUser = new SelectList(db.Users, "UserName", "Password");
            return View();
        }

        // POST: NppReturnGoodsCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReturnGoodsID,IDUser,SaleManID,DaReturnGoods,TotalAmount")] ReturnGood returnGood)
        {
            if (ModelState.IsValid)
            {
                db.ReturnGoods.Add(returnGood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SaleManID = new SelectList(db.SalesMen, "SalesManID", "SalesManName", returnGood.SaleManID);
            ViewBag.IDUser = new SelectList(db.Users, "UserName", "Password", returnGood.IDUser);
            return View(returnGood);
        }

        // GET: NppReturnGoodsCompany/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnGood returnGood = db.ReturnGoods.Find(id);
            if (returnGood == null)
            {
                return HttpNotFound();
            }
            ViewBag.SaleManID = new SelectList(db.SalesMen, "SalesManID", "SalesManName", returnGood.SaleManID);
            ViewBag.IDUser = new SelectList(db.Users, "UserName", "Password", returnGood.IDUser);
            return View(returnGood);
        }

        // POST: NppReturnGoodsCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReturnGoodsID,IDUser,SaleManID,DaReturnGoods,TotalAmount")] ReturnGood returnGood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returnGood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SaleManID = new SelectList(db.SalesMen, "SalesManID", "SalesManName", returnGood.SaleManID);
            ViewBag.IDUser = new SelectList(db.Users, "UserName", "Password", returnGood.IDUser);
            return View(returnGood);
        }

        // GET: NppReturnGoodsCompany/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnGood returnGood = db.ReturnGoods.Find(id);
            if (returnGood == null)
            {
                return HttpNotFound();
            }
            return View(returnGood);
        }

        // POST: NppReturnGoodsCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReturnGood returnGood = db.ReturnGoods.Find(id);
            db.ReturnGoods.Remove(returnGood);
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
