using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{ 
    public class StudentController : Controller
    {
        private StudentContext db = new StudentContext();

        //
        // GET: /Student/

        public ViewResult Index()
        {
            return View(db.StudentModels.ToList());
        }

        //
        // GET: /Student/Details/5

        public ViewResult Details(int id)
        {
            StudentModel studentmodel = db.StudentModels.Find(id);
            return View(studentmodel);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(StudentModel studentmodel)
        {
            if (ModelState.IsValid)
            {
                db.StudentModels.Add(studentmodel);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(studentmodel);
        }
        
        //
        // GET: /Student/Edit/5
 
        public ActionResult Edit(int id)
        {
            StudentModel studentmodel = db.StudentModels.Find(id);
            return View(studentmodel);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(StudentModel studentmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentmodel);
        }

        //
        // GET: /Student/Delete/5
 
        public ActionResult Delete(int id)
        {
            StudentModel studentmodel = db.StudentModels.Find(id);
            return View(studentmodel);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            StudentModel studentmodel = db.StudentModels.Find(id);
            db.StudentModels.Remove(studentmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}