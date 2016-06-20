using CSS.Models;
using CSS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSS.Controllers
{
    public class CustomerController : Controller
    {
        private CSSEntities1 db = new CSSEntities1();

        /// Function Search Customer
        /// searchModel: criteria search
        /// return: view SearchCustomer
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SearchCustomer()
        {
            SearchCustomerModel searchModel = new SearchCustomerModel();
            if (TryUpdateModel(searchModel))
            {
                SearchCustomerModel[] searchResult = null;
                //if user inputs rfo number, results will only search with rfo number
                if (searchModel.RFONumber != null)
                {
                    var results = from rfo in db.RFONumbers.Where(r => (r.RFONumber1 == searchModel.RFONumber))
                                  join com in db.Companies
                                  on rfo.CompanyId equals com.CompanyId
                                  join csm in db.CustomerTypes
                                  on rfo.CustomerTypeId equals csm.CustomerTypeId
                                  select new SearchCustomerModel
                                  {
                                      RFONumber = rfo.RFONumber1,
                                      SelectedCustomerType = rfo.CustomerType,
                                      Name = com.Name,
                                      PostCode = rfo.PostCode,
                                      BusinessArea = com.BusinessArea
                                  };
                    if (results != null)
                        searchResult = results.ToArray<SearchCustomerModel>();
                }
                //if user doesn't input rfo number, results won't search with rfo number
                else
                {
                    var results = from rfo in db.RFONumbers.Where(r => ((searchModel.SelectedCustomerType.CustomerTypeId == null
                                            || r.CustomerTypeId == searchModel.SelectedCustomerType.CustomerTypeId)
                                        && (string.IsNullOrEmpty(searchModel.PostCode) || r.PostCode.Contains(searchModel.PostCode))))

                                  join com in db.Companies.Where(co => ((string.IsNullOrEmpty(searchModel.Name) || co.Name.Contains(searchModel.Name))
                                        && (string.IsNullOrEmpty(searchModel.BusinessArea) || co.BusinessArea.Contains(searchModel.BusinessArea))))
                                    on rfo.CompanyId equals com.CompanyId

                                  join csm in db.CustomerTypes
                                    on rfo.CustomerTypeId equals csm.CustomerTypeId
                                  select new SearchCustomerModel
                                  {
                                      RFONumber = rfo.RFONumber1,
                                      SelectedCustomerType = rfo.CustomerType,
                                      Name = com.Name,
                                      PostCode = rfo.PostCode,
                                      BusinessArea = com.BusinessArea
                                  };
                    if (results != null)
                        searchResult = results.ToArray<SearchCustomerModel>();
                }
                if (searchResult == null)
                {
                    ViewBag.errorMessage = "Can not get customer data.";
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }
                else
                {
                    if (searchResult.Length > 0)
                    {
                        return PartialView("SearchCustomerResults", searchResult);
                    }
                    else
                    {
                        ViewBag.errorMessage = "Customer not found.";
                        return PartialView("~/Views/Shared/Warning.cshtml");
                    }
                }
            }
            else
            {
                ViewBag.errorMessage = "Can not receive search input.";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Test(string id)
        {

            return null;
        }
    }
}
