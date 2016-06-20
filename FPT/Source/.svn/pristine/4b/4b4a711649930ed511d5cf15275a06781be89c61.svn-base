using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service_Directory.Models;

namespace DepartmentDemo.Controllers
{
    public class DepartmentController : Controller
    {
        ServiceDirectoryDBEntities db = new ServiceDirectoryDBEntities();
        int depID;

        /// <summary>
        /// Load Index page 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("Department");
        }

        /// <summary>
        /// Get Data from Model
        /// </summary>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetDepartmentLists(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var departmentListsResults = db.Departments.Select(
                    a => new
                    {
                        a.DepartmentID,
                        a.DepartmentName,
                        a.DepartmentAddressLine1,
                        a.DepartmentPostcode,
                        a.ContactID
                    });

            int totalRecords = departmentListsResults.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sord.ToUpper() == "DESC")
            {
                departmentListsResults = departmentListsResults.OrderByDescending(s => s.DepartmentName);
                departmentListsResults = departmentListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                departmentListsResults = departmentListsResults.OrderBy(s => s.DepartmentName);
                departmentListsResults = departmentListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = departmentListsResults
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Show Department Details screen
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDepartmentDetail()
        {
            ViewBag.NationCountry = new SelectList(db.Countries, "CountryID", "CountryName");
            return View("AddDepartmentDetail");
        }

        /// <summary>
        /// Add Department to database
        /// </summary>
        /// <param name="fc"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddDepartment(FormCollection fc)
        {
            Department department = new Department();

            if (!ModelState.IsValid)
            {
                TempData["NameIsNull"] = "Please input the Department name";
                TempData["DescriptionIsNull"] = "Please input the short description";
            }

            if (ModelState.IsValid)
            {
                department.DepartmentName = fc["name"];
                department.DepartmentShortDescription = fc["shortDescription"];

                db.Departments.Add(department);
                db.SaveChanges();

                TempData["Success"] = "Save Department Successfully.";
            }
            return RedirectToAction("AddDepartmentDetail");
        }

        /// <summary>
        /// Amend Department item Action
        /// </summary>
        /// <param name="departmentID">id Department for edit</param>
        /// <returns></returns>
        public ActionResult AmendDepartmentDetails(int departmentID)
        {
            //depID = departmentID;
            var department = db.Departments.First(d => d.DepartmentID == departmentID);
            ViewBag.NationCountry = new SelectList(db.Countries, "CountryID", "CountryName");
            return View(department);
        }

        /// <summary>
        /// Amend Department Item
        /// </summary>
        /// <param name="fc">FormCollection for get value on fields</param>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AmendDepartment(FormCollection fc, int departmentID, string btnSubmit)
        {
            departmentID = Int32.Parse(fc["DepartmentID"]);
            var department = db.Departments.First(d => d.DepartmentID == departmentID);
            if (Request["btnSubmit"].Equals("Save"))
            {
                department.DepartmentID = departmentID;
                department.DepartmentName = fc["DepartmentName"];
                department.DepartmentShortDescription = fc["DepartmentShortDescription"];
                //UpdateModel(department);
                //db.SaveChanges();
            }
            if (Request["btnSubmit"].Equals("In-active"))
            {
                department.DepartmentStatus = true;
            }

            UpdateModel(department);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
