using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CMS2.Models;

namespace CMS2.Controllers
{
    public class CourseController : Controller
    {
        private CMSEntities db = new CMSEntities();

        // GET: Course
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Teacher);
            return View(courses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(string courseId)
        {
            if (courseId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(courseId);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }
      

        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName");
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCourse()
        {
            Course course = new Course();
            if (!TryUpdateModel(course))
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", course.TeacherId);
            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(string courseId)
        {
            if (courseId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(courseId);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", course.TeacherId);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            Course course = new Course();
            if (!TryUpdateModel(course))
                return HttpNotFound();
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", course.TeacherId);
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(string courseId)
        {
            if (courseId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(courseId);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string courseId)
        {
            Course course = db.Courses.Find(courseId);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Add students
        public ActionResult AddStudents(string courseId)
        {
            if (courseId == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var course = db.Courses.Find(courseId);
            if (course == null)
                return HttpNotFound();

            var registedStudents = from s in db.Students
                                   join e in db.Enrollments on s.StudentId equals e.StudentId
                                   join c in db.Courses on e.CourseId equals c.CourseId
                                   where c.CourseId == courseId
                                   select s;
            var unregistedStudents = db.Students.Except(registedStudents);
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
                            db.Enrollments.Add(e);
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

            var course = db.Courses.Find(courseId);
            if (course == null)
                return HttpNotFound();

            var registedStudents = from s in db.Students
                                   join e in db.Enrollments on s.StudentId equals e.StudentId
                                   join c in db.Courses on e.CourseId equals c.CourseId
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
                            Enrollment e = db.Enrollments.Find(csModel.Course.CourseId
                                , csModel.Students[i].StudentId);
                            if (e != null)
                                db.Enrollments.Remove(e);
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
