using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers
{
    public class StudentController : Controller
    {
        private CMS.Models.CSMContext db = new Models.CSMContext();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.DbStudent.ToList());
        }

        //GET: Edit student
        public ActionResult Edit(string studentId)
        { 
            if (studentId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Student student = db.DbStudent.Find(studentId);
            if (student == null)
                return HttpNotFound();
            else
                return View(student);
        }

        //POST: Edit student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        { 
            Student student = new Student();
            if (!TryUpdateModel(student))
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                db.Entry(student).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new{studentId = student.StudentId});
            }
            return View(student);
        }

        //GET Student details
        public ActionResult Details(string studentId)
        {
            if (studentId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Student student = db.DbStudent.Find(studentId);
            if (student == null)
                return HttpNotFound();
            else
                return View(student);
        }

        //GET: Delete student
        public ActionResult Delete(string studentId)
        {
            if (studentId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Student student = db.DbStudent.Find(studentId);
            if (student == null)
                return HttpNotFound();
            else
                return View(student);
        }

        //POST: Delete student
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string studentId)
        {
            if (studentId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Student student = db.DbStudent.Find(studentId);
            if (student == null)
                return HttpNotFound();

            var enrollments = from e in db.DbEnrollment
                              where e.StudentId == student.StudentId
                              select e;
            if (enrollments != null)
                db.DbEnrollment.RemoveRange(enrollments);
            db.DbStudent.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Create student
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create student
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudent()
        {
            Student student = new Student();
            if (!TryUpdateModel(student))
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                db.DbStudent.Add(student);
                db.SaveChanges();
                return RedirectToAction("Details", new { studentId = student.StudentId });
            }
            else
                return HttpNotFound();
        }
    }
}