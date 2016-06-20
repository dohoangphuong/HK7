using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSS_G06.Models;

namespace CSS_G06.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<HomeModel> allResult = new List<HomeModel>();
            using (var model = new CSSEntities())
            {
                var statusList = model.AgreementStatus.ToList();
                if (statusList != null)
                {
                    foreach (var status in statusList)
                    {
                        HomeModel modelItem = new HomeModel();
                        var agreement = model.Agreements.Where(agr => (agr.StatusId == status.StatusId)).ToList();
                        if (agreement == null)
                            modelItem.CountAgreementByStatus = 0;
                        else
                            modelItem.CountAgreementByStatus = agreement.Count;
                        modelItem.AgreementStatusId = status.StatusId;
                        modelItem.AgreementStatusName = status.AgreementStatus;
                        allResult.Add(modelItem);
                    }
                }
            }

            return View(allResult);
        }

        [HttpGet]
        public ActionResult AgreementByStatus(int statusId)
        {
            List<AgreementByStatus> allResult = new List<AgreementByStatus>();
            using (var model = new CSSEntities())
            {
                if (statusId > 0)
                {
                    var status = model.AgreementStatus.SingleOrDefault(stt => (stt.StatusId == statusId));
                    if (status == null)
                    {
                        ViewBag.TitleContent = "Cannot find agreement status with status's id = " + statusId;
                    }
                    else
                    {
                        var allAgreement = model.Agreements.Where(agr => (agr.StatusId == statusId)).Take(100).ToList();
                        if (allAgreement == null)
                        {
                            ViewBag.TitleContent = "Cannot find any agreement have status " + status.AgreementStatus;
                        }
                        else
                        {
                            bool isEdit = false;
                            if (statusId == 1)// draft
                                isEdit = true;

                            foreach (Agreement item in allAgreement)
                            {
                                AgreementByStatus result = new AgreementByStatus();
                                result.AgreementNumber = item.AgreementNumber;
                                result.VariantNumber = item.VariantNumber;
                                result.AgreementName = item.Name;
                                result.CreateBy = item.CreatedBy;
                                result.IsEdit = isEdit;
                                allResult.Add(result);
                            }
                            ViewBag.TitleContent = "Top 100 agreement have status " + status.AgreementStatus;
                        }
                    }
                }
                else
                { 
                    var allAgreement = (from agr in model.Agreements
                                        orderby agr.CreatedDate descending
                                         select agr).Take(100).ToList(); 
                        if (allAgreement == null)
                        {
                            ViewBag.TitleContent = "Cannot find any agreement in datatabase";
                        }
                        else
                        {
                            foreach (Agreement item in allAgreement)
                            {
                                AgreementByStatus result = new AgreementByStatus();
                                result.AgreementNumber = item.AgreementNumber;
                                result.VariantNumber = item.VariantNumber;
                                result.AgreementName = item.Name;
                                result.CreateBy = item.CreatedBy;
                                result.IsEdit = (item.StatusId == 1)? true:false;
                                allResult.Add(result);
                            }
                            ViewBag.TitleContent = "Top 100 agreement recently created";
                        }
                    }
                }
            return View(allResult);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}