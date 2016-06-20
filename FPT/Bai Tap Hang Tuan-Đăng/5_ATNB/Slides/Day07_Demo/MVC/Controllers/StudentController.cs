using System.Collections.Generic;
using System.Web.Mvc;
using MVC.Models;
using System.Linq;

namespace MVC.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/

        private static IList<StudentModel> students;

        public static IList<StudentModel> Students
        {
            get
            {
                if(students == null)
                {
                    students = new List<StudentModel>();
                }
                return students;
            }
        }

        public ActionResult Index()
        {
            return View(Students);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id)
        {
            
            // View details of Student
            StudentModel model = Students.First(s => s.ID == id);
            return View(model);
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
        public ActionResult Create(StudentModel student)
        {
            try
            {
                // This is only demo code, we can replace source code insert into database
                student.ID = Students.Count + 1;
                Students.Add(student);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Student/Edit/5
 
        public ActionResult Edit(int id)
        {
            StudentModel model = Students.First(s => s.ID == id);
            return View(model);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, StudentModel student)
        {
            try
            {
                // TODO: Add update logic here
                //Get existed student from the list
                StudentModel existed = Students.First(s => s.ID == id);
                existed.StudentName = student.StudentName;
                existed.Email = student.Email;
                existed.Phone = student.Phone;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Student/Delete/5
 
        public ActionResult Delete(int id)
        {
            StudentModel existed = Students.First(s => s.ID == id);
            return View(existed);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                StudentModel existed = Students.First(s => s.ID == id);
                Students.Remove(existed);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
