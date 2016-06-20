using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMS.Models;

namespace TMS.Controllers
{
    public class TraineeController : Controller
    {
        private TMSContext db = new TMSContext();

        //GET: Trainee/Login
        public ActionResult Login()
        {
            return View();
        }

        //GET: Trainee/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Account, Password")] Trainee unknownTrainee)
        {
            var trainee = db.DbTrainee.Where(
                t => (t.Account.Equals(unknownTrainee.Account) && t.Password.Equals(unknownTrainee.Password)))
                .FirstOrDefault();
            if (trainee == null)
                return View();
            else
                return RedirectToAction("Details", new { id = trainee.TraineeId });
        }

        //GET: Trainee/Review/id
        public ActionResult Review(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var enrollment = db.DbEnrollment
                .Where(e => (e.TraineeId == id && e.FeedbackId != null 
                    && e.Feedback.Complete == false))
                .FirstOrDefault();
            if (enrollment == null)
            {
                return HttpNotFound();
            }

            var fbdetails = from fb in db.DbFeedback
                                join fd in db.DbFeedbackDetail on fb.FeedbackId equals fd.FeedbackId
                            where fb.FeedbackId == enrollment.FeedbackId
                            select fd;
            if (fbdetails == null)
            {
                return HttpNotFound();
            }

            //using explicit loading
            foreach (var fd in fbdetails)
            {
                db.Entry(fd).Reference(p => p.FeedbackType).Load();
            }
            
            return View(fbdetails);
        }

        //POST: Trainee/Review/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Review(IEnumerable<FeedbackDetail> fbDetails)
        {
            return View();
        }

        // GET: Trainee
        public ActionResult Index()
        {
            return View(db.DbTrainee.ToList());
        }

        // GET: Trainee/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.DbTrainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // GET: Trainee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraineeId,TraineeNo,FirstName,LastName,Email,Account,Password")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.DbTrainee.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = trainee.TraineeId });
            }

            return View(trainee);
        }

        // GET: Trainee/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.DbTrainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraineeId,FirstName,LastName,Email,Account,Password")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = trainee.TraineeId });
            }
            return View(trainee);
        }

        // GET: Trainee/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainee trainee = db.DbTrainee.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        // POST: Trainee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Trainee trainee = db.DbTrainee.Find(id);
            db.DbTrainee.Remove(trainee);
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
