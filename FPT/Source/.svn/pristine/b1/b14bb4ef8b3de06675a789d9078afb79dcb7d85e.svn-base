using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Models;
using System.Net;

namespace CMS.Controllers
{
    public class CourseController : Controller
    {
        private CSMContext db = new CSMContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Course
        public ActionResult Index()
        {
            return View(db.DbCourse.ToList());
        }

        // GET: Add students
        public ActionResult AddStudents(string courseId)
        {
            if (courseId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = db.DbCourse.Find(courseId);
            if (course == null)
                return HttpNotFound();

            var registedStudents = from s in db.DbStudent
                               join e in db.DbEnrollment on s.StudentId equals e.StudentId
                               join c in db.DbCourse on e.CourseId equals c.CourseId
                           where c.CourseId == courseId
                           select s;
            var unregistedStudents = db.DbStudent.Except(registedStudents);
            if (unregistedStudents == null)
                return HttpNotFound();

            return View(new CourseStudentsModel(course, unregistedStudents.ToList()));
        }

        // POST: Add students
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudents()
        {
            CourseStudentsModel csModel = new CourseStudentsModel();
            if (TryUpdateModel(csModel))
            {
                if (csModel.Students == null || csModel.Students.Count == 0)
                    return RedirectToAction("Index");
                if (ModelState.IsValid)
                {
                    for (int i = 0; i < csModel.CheckStudents.Length; i++)
                    {
                        if (csModel.CheckStudents[i])
                        {
                            Enrollment e = new Enrollment(csModel.Course.CourseId
                                , csModel.Students[i].StudentId);
                            db.DbEnrollment.Add(e);
                        }
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("AddStudents", new { courseId = csModel.Course.CourseId });
            }
            else
                return HttpNotFound();
        }

        // GET: Remove students
        public ActionResult RemoveStudents(string courseId)
        {
            if (courseId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = db.DbCourse.Find(courseId);
            if (course == null)
                return HttpNotFound();

            var registedStudents = from s in db.DbStudent
                                   join e in db.DbEnrollment on s.StudentId equals e.StudentId
                                   join c in db.DbCourse on e.CourseId equals c.CourseId
                                   where c.CourseId == courseId
                                   select s;
            if (registedStudents == null)
                return HttpNotFound();

            return View(new CourseStudentsModel(course, registedStudents.ToList()));
        }

        // POST: Remove students
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveStudents()
        {
            CourseStudentsModel csModel = new CourseStudentsModel();
            if (TryUpdateModel(csModel))
            {
                if (csModel.Students == null || csModel.Students.Count == 0)
                    return RedirectToAction("Index");
                if (ModelState.IsValid)
                {
                    for (int i = 0; i < csModel.CheckStudents.Length; i++)
                    {
                        if (csModel.CheckStudents[i])
                        {
                            Enrollment e = db.DbEnrollment.Find(csModel.Course.CourseId
                                , csModel.Students[i].StudentId);
                            if (e != null)
                                db.DbEnrollment.Remove(e);
                        }
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("AddStudents", new { courseId = csModel.Course.CourseId });
            }
            else
                return HttpNotFound();
        }

        //GET: Create course
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create course
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCourse()
        {
            Course course = new Course();
            if (!TryUpdateModel(course))
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                db.DbCourse.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return HttpNotFound();
        }

        //GET: Course details
        public ActionResult Details(string courseId)
        {
            if (courseId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Course course = db.DbCourse.Find(courseId);
            if (course == null)
                return HttpNotFound();
            else
                return View(course);
        }

        //GET: Edit course
        public ActionResult Edit(string courseId)
        {
            if (courseId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Course course = db.DbCourse.Find(courseId);
            if (course == null)
                return HttpNotFound();
            else
                return View(course);
        }

        //POST: Edit course
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        { 
            Course course = new Course();
            if (!TryUpdateModel(course))
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                db.Entry(course).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new{courseId = course.CourseId});
            }
            return View(course);
        }

        //GET: Delete course
        public ActionResult Delete(string courseId)
        {
            if (courseId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Course course = db.DbCourse.Find(courseId);
            if (course == null)
                return HttpNotFound();
            return View(course);
        }

        // POST: Delete course
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string courseId)
        {
            if (courseId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Course course = db.DbCourse.Find(courseId);
            if (course == null)
                return HttpNotFound();
            var enrollments = from e in db.DbEnrollment
                              where e.CourseId == course.CourseId 
                              select e;
            if (enrollments != null)
                db.DbEnrollment.RemoveRange(enrollments);
            db.DbCourse.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}