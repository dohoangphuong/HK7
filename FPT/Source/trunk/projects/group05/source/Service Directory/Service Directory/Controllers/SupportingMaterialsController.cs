using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Service_Directory.Models;

namespace Service_Directory.Controllers
{
    public class SupportingMaterialsController : Controller
    {
        ServiceDirectoryDBEntities db = new ServiceDirectoryDBEntities();

        List<SelectListItem> items = new List<SelectListItem>();

        //
        // GET: /SupportingMaterials/

        public ActionResult Index()
        {
            return View("SupportingMaterials");
        }

        public ActionResult SupportingMaterialsDetail()
        {
            items.Add(new SelectListItem { Text = "Doc", Value = "Doc" });

            items.Add(new SelectListItem { Text = "Excel", Value = "Excel" });

            items.Add(new SelectListItem { Text = "Pdf", Value = "Pdf", Selected = true });
            ViewBag.Type = items;
            return View();
        }

        [HttpPost]
        public ActionResult AddSupportingMaterials(FormCollection fc)
        {
            SupportingMaterial supporting = new SupportingMaterial();

            if (!ModelState.IsValid)
            {
                TempData["urlIsNull"] = "Please input the Supporting Materials url";
            }

            if (ModelState.IsValid)
            {
                supporting.URL = fc["url"];
                supporting.SupportingMaterialDescription = fc["Description"];
                supporting.Type = fc["Type"];
                //supporting.AddedDate = Convert.ToDateTime(fc["AddedDate"]);

                db.SupportingMaterials.Add(supporting);
                db.SaveChanges();

                TempData["Success"] = "Save Supporting Materials Successfully.";
            }
            return RedirectToAction("AddSupportingMaterialsDetail");
        }

        public JsonResult GetSupportingMaterialsLists(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var SupportingMaterialsListsResults = db.SupportingMaterials.Select(
                    a => new
                    {
                        a.SupportingMaterialID,
                        a.UserID,
                        a.OrgID,
                        a.URL,
                        a.Type,
                        a.AddedDate,
                        a.SupportingMaterialDescription
                    });

            int totalRecords = SupportingMaterialsListsResults.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

            if (sord.ToUpper() == "DESC")
            {
                SupportingMaterialsListsResults = SupportingMaterialsListsResults.OrderByDescending(s => s.URL);
                SupportingMaterialsListsResults = SupportingMaterialsListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            }
            //else
            //{
            //    SupportingMaterialsListsResults = SupportingMaterialsListsResults.OrderBy(s => s.URL);
            //    SupportingMaterialsListsResults = SupportingMaterialsListsResults.Skip(pageIndex * pageSize).Take(pageSize);
            //}

            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = SupportingMaterialsListsResults
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult AddSupportingMaterialsDetail()
        {
            items.Add(new SelectListItem { Text = "Doc", Value = "Doc" });

            items.Add(new SelectListItem { Text = "Excel", Value = "Excel" });

            items.Add(new SelectListItem { Text = "Pdf", Value = "Pdf", Selected = true });
            ViewBag.Type = items;
            return View("AddSupportingMaterialsDetail");
        }

        

        /// <summary>
        /// Amend SupportingMaterials item Action
        /// </summary>
        /// <param name="SupportingMaterialsID">id SupportingMaterialst for edit</param>
        /// <returns></returns>
        public ActionResult AmendSupportingMaterialsDetails(int supportingMaterialID)
        {
            var supporting = db.SupportingMaterials.First(d => d.SupportingMaterialID == supportingMaterialID);
            items.Add(new SelectListItem { Text = "Doc", Value = "Doc" });

            items.Add(new SelectListItem { Text = "Excel", Value = "Excel" });

            items.Add(new SelectListItem { Text = "Pdf", Value = "Pdf", Selected = true });
            ViewBag.Type = items;
            return View(supporting);
        }

        /// <summary>
        /// Amend SupportingMaterials Item
        /// </summary>
        /// <param name="fc">FormCollection for get value on fields</param>
        /// <param name="SupportingMaterialsID"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AmendSupportingMaterials(FormCollection fc, int SupportingMaterialID, string btnSubmit)
        {
            SupportingMaterialID = Int32.Parse(fc["SupportingMaterialID"]);
            var supporting = db.SupportingMaterials.First(d => d.SupportingMaterialID == SupportingMaterialID);

            if (Request["btnSubmit"].Equals("Save"))
            {
                supporting.SupportingMaterialID = SupportingMaterialID;
                supporting.URL = fc["URL"];
                supporting.SupportingMaterialDescription = fc["Sescription"];
            }
            if (Request["btnSubmit"].Equals("In-active"))
            {
                
            }

            UpdateModel(supporting);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
