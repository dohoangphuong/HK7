using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSS.Models;
using System.IO;
using System.Data.Entity.Validation;
using PagedList;
using System.Data.Entity;

namespace CSS.Controllers
{
    public class MaintainController : Controller
    {
        private CSSEntities1 db = new CSSEntities1();

        /// <summary>
        /// Download file from server
        /// </summary>
        /// <param name="file">Location of file in server</param>
        /// <param name="fileName">Filename to user in userend</param>
        /// <returns></returns>
        public FileResult Download(string file, string fileName)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(file);
            var response = new FileContentResult(fileBytes, "application/octet-stream");
            response.FileDownloadName = fileName;
            return response;
        }

        /// <summary>
        /// UC29: Funding method home screen
        /// </summary>
        /// <param name="page"></param>
        /// <param name="searchString"></param>
        /// <returns></returns>
        public ActionResult FundingMethod(int? page = 1, string searchString = null)
        {
            if (Request.IsAuthenticated)
            {
                List<FundingMethod> fundingMethods = db.FundingMethods.ToList();
                //If user have search filter
                if (!String.IsNullOrEmpty(searchString))
                {
                    fundingMethods = fundingMethods.Where(s => s.FundingMethodName.Contains(searchString)).ToList();
                }
                //Pagination
                int pageSize = 8;
                int pageNumber = (page ?? 1);

                return View(fundingMethods.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Add new funding method
        /// </summary>
        /// <returns></returns>
        public ActionResult AddFundingMethod()
        {
            if (Request.IsAuthenticated)
            {
                //Funding type
                ViewBag.FundingTypes = db.SYSCFTs.Find(7).SYSCVTs.ToList();
                //Signed Contact Default
                ViewBag.SignedContractDefaults = db.SYSCFTs.Find(14).SYSCVTs.ToList();
                //Funding status
                ViewBag.FundingStatus = db.SYSCFTs.Find(8).SYSCVTs.ToList();
                //BudgetCode
                ViewBag.BudgetCodes = db.BudgetCodes.ToList();
                //CostCentre
                ViewBag.CostCentres = db.CostCentres.ToList();

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// POST method of add new funding method , saving method to database
        /// </summary>
        /// <param name="fundingMethod">FundingMethod model</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddFundingMethod([Bind(Exclude = "FundingMethodId")]FundingMethod fundingMethod)
        {
            //Validate model
            if (ModelState.IsValid)
            {
                bool isFileExist = false;
                string extension = null;
                //Check if user had choosed any file and save infomation to db
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        isFileExist = true;
                        fundingMethod.FileName = Path.GetFileName(file.FileName);
                        extension = Path.GetExtension(file.FileName);
                    }
                }

                //Add funding method to database
                db.FundingMethods.Add(fundingMethod);
                db.SaveChanges();

                //Save file to server with funding method ID as name
                if (isFileExist)
                {
                    var file = Request.Files[0];
                    //New file name to store = funding method ID
                    string newFileName = fundingMethod.FundingMethodId + extension;
                    string path = Path.Combine(Server.MapPath("~/Resources/Documents/"), newFileName);
                    fundingMethod.ContractTemplateLocation = path;
                    file.SaveAs(path);
                    db.SaveChanges();
                }

                return RedirectToAction("FundingMethod");
            }
            else //If model state is invalid return to View
            {
                //Funding type
                ViewBag.FundingTypes = db.SYSCFTs.Find(7).SYSCVTs.ToList();
                //Signed Contact Default
                ViewBag.SignedContractDefaults = db.SYSCFTs.Find(14).SYSCVTs.ToList();
                //Funding status
                ViewBag.FundingStatus = db.SYSCFTs.Find(8).SYSCVTs.ToList();
                //BudgetCode
                ViewBag.BudgetCodes = db.BudgetCodes.ToList();
                //CostCentre
                ViewBag.CostCentres = db.CostCentres.ToList();
                return View(fundingMethod);
            }
        }

        //
        /// <summary>
        /// Edit a fungding method
        /// </summary>
        /// <param name="id">Funding method ID</param>
        /// <returns>Edit funding method screen</returns>
        public ActionResult EditFundingMethod(int id)
        {
            if (Request.IsAuthenticated)
            {
                FundingMethod fundingMethod = db.FundingMethods.Find(id);
                if (fundingMethod == null)
                {
                    return HttpNotFound();
                }

                //Funding type
                ViewBag.FundingTypes = db.SYSCFTs.Find(7).SYSCVTs.ToList();
                //Signed Contact Default
                ViewBag.SignedContractDefaults = db.SYSCFTs.Find(14).SYSCVTs.ToList();
                //Funding status
                ViewBag.FundingStatus = db.SYSCFTs.Find(8).SYSCVTs.ToList();
                //BudgetCode
                ViewBag.BudgetCodes = db.BudgetCodes.ToList();
                //CostCentre
                ViewBag.CostCentres = db.CostCentres.ToList();
                return View(fundingMethod);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// POST method of edit: Save edited funding method to database
        /// </summary>
        /// <param name="fundingMethod">FundingMethod model</param>
        /// <returns>Homepage of funding method</returns>
        [HttpPost]
        public ActionResult EditFundingMethod(FundingMethod fundingMethod)
        {
            if (ModelState.IsValid)
            {
                //Save file to server
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        fundingMethod.FileName = Path.GetFileName(file.FileName);
                        string extension = Path.GetExtension(file.FileName);
                        //New file name to store = funding method ID
                        string newFileName = fundingMethod.FundingMethodId + extension;
                        string path = Path.Combine(Server.MapPath("~/Resources/Documents/"), newFileName);
                        fundingMethod.ContractTemplateLocation = path;
                        file.SaveAs(path);
                    }
                }

                db.Entry(fundingMethod).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("FundingMethod");
            }
            else
            {
                //Funding type
                ViewBag.FundingTypes = db.SYSCFTs.Find(7).SYSCVTs.ToList();
                //Signed Contact Default
                ViewBag.SignedContractDefaults = db.SYSCFTs.Find(14).SYSCVTs.ToList();
                //Funding status
                ViewBag.FundingStatus = db.SYSCFTs.Find(8).SYSCVTs.ToList();
                //BudgetCode
                ViewBag.BudgetCodes = db.BudgetCodes.ToList();
                //CostCentre
                ViewBag.CostCentres = db.CostCentres.ToList();
                return View(fundingMethod);
            }
        }

        /// <summary>
        /// Confirm delete a funding method
        /// </summary>
        /// <param name="id">ID of deleted funding method</param>
        /// <returns>Screen confirm to delete a method</returns>
        public ActionResult DeleteFundingMethod(int id = 0)
        {
            FundingMethod fundingMethod = db.FundingMethods.Find(id);
            if (fundingMethod == null)
            {
                return HttpNotFound();
            }
            if (fundingMethod.Agreements.Count > 0)
            {
                return View("DeleteFundingMethodError", fundingMethod);
            }
            else
            {
                return View(fundingMethod);
            }
        }

        

        /// <summary>
        /// Delete a funding method after confirm
        /// </summary>
        /// <param name="id">ID of deleted funding method</param>
        /// <returns>Home of funding method</returns>
        [HttpPost, ActionName("DeleteFundingMethod")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFundingMethodConfirmed(int id)
        {
            FundingMethod fundingMethod = db.FundingMethods.Find(id);
            db.FundingMethods.Remove(fundingMethod);
            db.SaveChanges();
            return RedirectToAction("FundingMethod");
        }
    }
}
