using CSS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSS.Models;

namespace CSS.Controllers
{
    public class DealerController : Controller
    {
        private CSSEntities1 db = new CSSEntities1();

        /// Get all dealer
        /// 
        /// return view SearchDealerResults
        [HttpPost]
        public ActionResult GetAllDealer()
        {
            //query many to many relationship
            var dealers = from rfo in db.RFOUsers
                          from addr in db.ContactAddresses
                              .Where(ad => ad.UserId == rfo.UserId).Take(1)
                          select (new DealerSelectionModel()
                          {
                              Code = rfo.UserId,
                              DealerName = rfo.FirstName + " " + rfo.LastName,
                              Town = addr.Town,
                              County = addr.County
                          });

            if (dealers == null)
            {
                ViewBag.errorMessage = "Can not get dealer data";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }
            else
            {
                var searchResults = dealers.ToArray<DealerSelectionModel>();
                if (searchResults.Length > 0)
                    return PartialView("SearchDealerResults", searchResults);
                else
                {
                    ViewBag.errorMessage = "Dealer Not Found";
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }
            }
        }

        /// Function Search Dealer
        /// searchModel: criteria search 
        /// return: view SearchDealerResults
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SearchDealer()
        {
            SearchDealerModel searchModel = new SearchDealerModel();
            if (TryUpdateModel(searchModel))
            {
                //query many to many relationship
                var dealers = from rfo in db.RFOUsers.Where(r =>
                        (
                            (searchModel.Code == null || r.UserId == searchModel.Code)
                            && (string.IsNullOrEmpty(searchModel.DealerName)
                                || (r.FirstName + r.LastName).Contains(searchModel.DealerName))
                        ))
                              from addr in db.ContactAddresses.Where(ad => ad.UserId == rfo.UserId).Take(1)
                              select new DealerSelectionModel()
                              {
                                  Code = rfo.UserId,
                                  DealerName = rfo.FirstName + " " + rfo.LastName,
                                  Town = addr.Town,
                                  County = addr.County
                              };
                if (dealers == null)
                {
                    ViewBag.errorMessage = "Can not get dealer data";
                    return PartialView("~/View/Agreement/Warning.cshtml");
                }
                else
                {
                    var searchResults = dealers.ToArray<DealerSelectionModel>();
                    if (searchResults.Length > 0)
                        return PartialView("SearchDealerResults", searchResults);
                    else
                    {
                        ViewBag.errorMessage = "Dealer Not Found";
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

        /// Save dealers to agreement
        /// dealersAdd: list dealer need to add
        /// dealersDelete: list dealer need to delete
        /// agreementNumber: AgreementNumber
        /// varriantNumber: AgreementVariant
        /// return an alert
        [HttpPost]
        public ActionResult SaveDealers(int[] dealersAdd, int[] dealersDelete
            , int agreementNumber = 0, int varriantNumber = 0)
        {
            var agrmt = db.Agreements.Find(agreementNumber, varriantNumber);
            if (agrmt == null)
            {
                ViewBag.errorMessage = "Agreement not found.";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }
            else
            {
                try
                {
                    //delete dealers from delete list
                    if (dealersDelete != null)
                    {
                        foreach (var dealerId in dealersDelete)
                        {
                            var dealer = db.RFOUsers.Find(dealerId);
                            if (dealer != null
                                && agrmt.RFOUsers.Any(a => a.UserId == dealer.UserId))
                            {
                                agrmt.RFOUsers.Remove(dealer);
                            }
                        }
                    }

                    //add dealers from add list
                    if (dealersAdd != null)
                    {
                        foreach (var dealerId in dealersAdd)
                        {
                            var dealer = db.RFOUsers.Find(dealerId);
                            if (dealer != null
                                && !agrmt.RFOUsers.Any(a => a.UserId == dealer.UserId))
                            {
                                agrmt.RFOUsers.Add(dealer);
                            }
                        }
                    }

                    //add empty volume to agreemetn
                    Volume vol = new Volume();
                    vol.Agreements.Add(agrmt);

                    db.Entry(agrmt).State = System.Data.Entity.EntityState.Modified;
                    db.Volumes.Add(vol);

                    //save to database
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.errorMessage = "Assign dealers to agreement failed. " + ex.Message;
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }

                return PartialView("~/Views/Shared/Alert.cshtml");
            }
        }

    }
}
