using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service_Directory.Models;

namespace DirectorateDemo.Controllers
{
    public class DirectoratesController : Controller
    {
        ServiceDirectoryDBEntities db = new ServiceDirectoryDBEntities();

        //
        // GET: /DIRECTORATE/

        public ActionResult Index()
        {
            return View("Directorates");
        }

        public JsonResult GetDirectoratesLists(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var directoratesListsResults = db.Directorates.Select(
                    a => new
                    {
                        a.DirectorateID,
                        a.DirectorateName,
                        a.DirectorateAddressLine1,
                        a.ContactID,
                        a.DirectoratePostcode,
                        a.DirectorateStatus
                    });

            int totalRecords = directoratesListsResults.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                directoratesListsResults = directoratesListsResults.OrderByDescending(s => s.DirectorateName);
                directoratesListsResults = directoratesListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                directoratesListsResults = directoratesListsResults.OrderBy(s => s.DirectorateName);
                directoratesListsResults = directoratesListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = directoratesListsResults
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDirectoratesDetail()
        {
            ViewBag.NationCountry = new SelectList(db.Countries, "CountryID", "CountryName");
            return View("AddDirectoratesDetail");
        }

        [HttpPost]
        public ActionResult AddDirectorates(FormCollection fc)
        {
            Directorate directorates = new Directorate();

            if (!ModelState.IsValid)
            {
                TempData["NameIsNull"] = "Please input the Directorate name";
                TempData["DescriptionIsNull"] = "Please input the short description";
            }

            if (ModelState.IsValid)
            {
                directorates.DirectorateName = fc["name"];
                directorates.DirectorateShortDescription = fc["shortDescription"];

                db.Directorates.Add(directorates);
                db.SaveChanges();

                TempData["Success"] = "Save Directorate Successfully.";
            }
            return RedirectToAction("AddDirectoratesDetail");
        }


        public ActionResult AmendDirectorateDetails(int directorateID)
        {
            var directorate = db.Directorates.First(d => d.DirectorateID == directorateID);
            ViewBag.NationCountry = new SelectList(db.Countries, "CountryID", "CountryName");
            return View(directorate);
        }

        public ActionResult AmendDirectorate(FormCollection fc, int directorateID, string btnSubmit)
        {
            directorateID = Int32.Parse(fc["DirectorateID"]);
            var directorate = db.Directorates.First(d => d.DirectorateID == directorateID);
            if (Request["btnSubmit"].Equals("Save"))
            {
                directorate.DirectorateID = directorateID;
                directorate.DirectorateName = fc["DIRECTORATEName"];
                directorate.DirectorateShortDescription = fc["DIRECTORATEShortDescription"];
                //UpdateModel(DIRECTORATE);
                //db.SaveChanges();
            }
            if (Request["btnSubmit"].Equals("In-active"))
            {
                
            }

            UpdateModel(directorate);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

       
       
    }
}
