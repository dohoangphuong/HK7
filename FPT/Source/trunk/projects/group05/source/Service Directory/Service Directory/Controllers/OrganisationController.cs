using Service_Directory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Directory.Controllers
{
    public class OrganisationController : Controller
    {
        ServiceDirectoryDBEntities sd = new ServiceDirectoryDBEntities();

        //
        // GET: /Organisation/

        public ActionResult Index()
        {
            return View("Organisation");
        }

        public ActionResult AddOrganisationDetail()
        {
            ViewBag.NationCountry = new SelectList(sd.Countries, "CountryID", "CountryName");
            return View("AddOrganisationDetail");
        }

        [HttpPost]
        public ActionResult AddOrganisation(FormCollection fc)
        {
            Organisation organisation = new Organisation();

            if (!ModelState.IsValid)
            {
                TempData["NameIsNull"] = "Please input the Organisation name";
                TempData["DescriptionIsNull"] = "Please input the short description";
            }

            if (ModelState.IsValid)
            {
                organisation.OrgName = fc["name"];
                organisation.OrganisationShortDescription = fc["shortDescription"];
                organisation.OrganisationPostode = fc["addressLin1"];
                organisation.OrganisationAddressLine1 = fc["postode"];
                sd.Organisations.Add(organisation);
                sd.SaveChanges();

                TempData["Success"] = "Save Organisation Successfully.";
            }
            return RedirectToAction("AddOrganisationDetail");
        }

        ServiceDirectoryDBEntities db = new ServiceDirectoryDBEntities();
        public JsonResult GetOrganisationLists(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var OrganisationListsResults = db.Organisations.Select(
                    a => new
                    {
                        a.OrgID,
                        a.OrgName,
                        a.OrganisationAddressLine1,
                        a.OrganisationPostode,
                        a.ContactID
                    });

            int totalRecords = OrganisationListsResults.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            //if (sord.ToUpper() == "DESC")
            //{
            //    OrganisationListsResults = OrganisationListsResults.OrderByDescending(s => s.OrgName);
            //    OrganisationListsResults = OrganisationListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            //}
            //else
            //{
            //    OrganisationListsResults = OrganisationListsResults.OrderBy(s => s.OrgName);
            //    OrganisationListsResults = OrganisationListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            //}
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = OrganisationListsResults
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AmendOrganisationDetails(int OrgID)
        {
            var organisation = db.Organisations.First(d => d.OrgID == OrgID);
            ViewBag.NationCountry = new SelectList(db.Countries, "CountryID", "CountryName");
            return View(organisation);
        }
        [HttpPost]
        public ActionResult AmendOrganisation(FormCollection fc, int OrgID, string btnSubmit)
        {
            OrgID = Int32.Parse(fc["OrgID"]);
            var organisation = db.Organisations.First(d => d.OrgID == OrgID);
            if (Request["btnSubmit"].Equals("Save"))
            {
                organisation.OrgID = OrgID;
                organisation.OrgName = fc["OrgName"];
                organisation.OrganisationShortDescription = fc["OrganisationShortDescription"];
                //UpdateModel(department);
                //db.SaveChanges();
            }
            //if (Request["btnSubmit"].Equals("In-active"))
            //{
            //    organisation.OrganisationStatus = true;
            //}

            UpdateModel(organisation);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

