using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ServicesDirectory.DataAccess;
using ServicesDirectory.Models.ControllerModels;
using ServicesDirectory.Models.DatabaseMapper;
using ServicesDirectory.Models.ViewModels;

namespace ServicesDirectory.Controllers
{
    public class ServiceController : Controller
    {
        private ABSDDatabaseEntities db = new ABSDDatabaseEntities();

        //
        // GET: /Service/

        public ActionResult Index()
        {
            var services = db.Services.Include(s => s.Contact).Include(s => s.ContractParticipationType).Include(s => s.Programme).Include(s => s.ReferralMethod).Include(s => s.ServiceSubType).Include(s => s.ServiceType);
            return View(services.ToList());
        }

        public ActionResult ServiceDetails(string page_action = "new", int service_id = -1)
        {
            ServiceDetailViewModel viewModel = new ServiceDetailViewModel();
            ServiceDataAccess serviceDataAccess = new ServiceDataAccess();
            ContactDataAccess contactDataAccess = new ContactDataAccess();
            ReferralMethodDataAccess referralMethodDataAccess = new ReferralMethodDataAccess();
            ServiceSubTypeDataAccess serviceSubTypeDataAccess = new ServiceSubTypeDataAccess();
            ServiceTypeDataAccess serviceTypeDataAccess = new ServiceTypeDataAccess();
            RefDataDataAccess refDataDataAccess = new RefDataDataAccess();

            //Load common data:
            viewModel.ServiceTypeList = serviceTypeDataAccess.GetAllServiceTypes();
            viewModel.ServiceSubTypeList = serviceSubTypeDataAccess.GetAllServiceSubTypes();
            viewModel.ServiceContactList = contactDataAccess.GetAllContacts();
            viewModel.ReferralMethodList = referralMethodDataAccess.GetAllReferralMethods();

            //Load service data:
            if(service_id == -1 || page_action == "new")
            {
                viewModel.Service = new Service();
            }
            else
            {
                try
                {
                    viewModel.Service = serviceDataAccess.GetServiceById(service_id);
                }
                catch(Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                    viewModel.Service = new Service();
                }
                
                if(viewModel.Service == null)
                {
                    viewModel.Service = new Service();
                }
            }

            //Load List checkboxed data:
            if (service_id == -1 || page_action == "new")
            {
                viewModel.BenefitsCriterionChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.ServiceBenefitsCriterion.Replace(" ", ""));
                viewModel.BarriersCriterionChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.ServiceBarriersCriterion.Replace(" ", ""));
                viewModel.EthnicityCriterionChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.ServiceEthnicityCriterion.Replace(" ", ""));
                viewModel.DisabilityCriterionChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.ServiceDisabilityCriterion.Replace(" ", ""));
                viewModel.PersonalCircumstancesChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.ServicePersonalCircumstancesCriterion.Replace(" ", ""));
                viewModel.OtherServiceParticipationCriterionChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.OtherServiceParticipationCriterion.Replace(" ", ""));

                viewModel.ClientSupportProcessChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.ClientSupportProcess.Replace(" ", ""));

                viewModel.ContractOutcomeChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.ContractOutcome.Replace(" ", ""));
                viewModel.ContractObligationChildren = refDataDataAccess.GetRefDataDetailUIs(RefDataConstants.ContractObligation.Replace(" ", ""));
            }
            else
            {
                viewModel.BenefitsCriterionChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.ServiceBenefitsCriterion.Replace(" ", ""), service_id);
                viewModel.BarriersCriterionChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.ServiceBarriersCriterion.Replace(" ", ""), service_id);
                viewModel.EthnicityCriterionChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.ServiceEthnicityCriterion.Replace(" ", ""), service_id);
                viewModel.DisabilityCriterionChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.ServiceDisabilityCriterion.Replace(" ", ""), service_id);
                viewModel.PersonalCircumstancesChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.ServicePersonalCircumstancesCriterion.Replace(" ", ""), service_id);
                viewModel.OtherServiceParticipationCriterionChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.OtherServiceParticipationCriterion.Replace(" ", ""), service_id);

                viewModel.ClientSupportProcessChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.ClientSupportProcess.Replace(" ", ""), service_id);

                viewModel.ContractOutcomeChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.ContractOutcome.Replace(" ", ""), service_id);
                viewModel.ContractObligationChildren = refDataDataAccess.GetRefDataDetailUIsWithIsChecked(RefDataConstants.ContractObligation.Replace(" ", ""), service_id);
            }
            return View(viewModel);
        }

        //
        // GET: /Service/Details/5

        public ActionResult Details(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // GET: /Service/Create

        public ActionResult Create()
        {
            ViewBag.LeadContactId = new SelectList(db.Contacts, "ContactId", "FirstName");
            ViewBag.ContractParticipationTypeId = new SelectList(db.ContractParticipationTypes, "ContractParticipationTypeId", "ContractParticipationTypeName");
            ViewBag.ProgrammeId = new SelectList(db.Programmes, "ProgrammeId", "ProgrammeName");
            ViewBag.ReferralMethodId = new SelectList(db.ReferralMethods, "ReferralMethodId", "ReferralMethodName");
            ViewBag.ServiceSubTypeId = new SelectList(db.ServiceSubTypes, "ServiceSubTypeId", "ServiceSubTypeName");
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "ServiceTypeId", "ServiceTypeName");
            return View();
        }

        //
        // POST: /Service/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LeadContactId = new SelectList(db.Contacts, "ContactId", "FirstName", service.LeadContactId);
            ViewBag.ContractParticipationTypeId = new SelectList(db.ContractParticipationTypes, "ContractParticipationTypeId", "ContractParticipationTypeName", service.ContractParticipationTypeId);
            ViewBag.ProgrammeId = new SelectList(db.Programmes, "ProgrammeId", "ProgrammeName", service.ProgrammeId);
            ViewBag.ReferralMethodId = new SelectList(db.ReferralMethods, "ReferralMethodId", "ReferralMethodName", service.ReferralMethodId);
            ViewBag.ServiceSubTypeId = new SelectList(db.ServiceSubTypes, "ServiceSubTypeId", "ServiceSubTypeName", service.ServiceSubTypeId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "ServiceTypeId", "ServiceTypeName", service.ServiceTypeId);
            return View(service);
        }

        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            if(ModelState.IsValid)
            {
                db.Services.Add(service);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                    return Json(new { is_succeeded = false, error_msg = e.Message, service_id = -1});
                }
            }
            return Json(new { is_succeeded = true, error_msg = string.Empty, service_id = service.ServiceId });
        }

        [HttpPost]
        public ActionResult LinkServiceToRefDataDetails_Detail2(int[] ref_data_detail_ids = null, int service_id = -1)
        {
            //int[] ref_data_detail_ids = new int[]{};
            //int service_id = -1;
            RefDataDataAccess refDataDataAccess = new RefDataDataAccess();
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            try
            {
                //Find possible RefDataDetailId that can link to the service (Only RefDataDetail used in Detail 2 tab):
                List<int> possibleRefDetailIds = new List<int>();
                List<RefDataDetail> refDataDetails = refDataDataAccess.GetRefDataDetails(RefDataConstants.ServiceDetails_Details2_ListCheckboxName);
                foreach(var item in refDataDetails)
                {
                    possibleRefDetailIds.Add(item.RefDataDetailId);
                }

                //Remove all possible RefDataDetail:
                refDataDataAccess.RemoveRefDataDetailsLinkedToService(service_id, possibleRefDetailIds.ToArray());

                //Link RefDataDetail that has id in ref_data_detail_ids to the service:
                refDataDataAccess.LinkRefDataDetailsToService(service_id, ref_data_detail_ids);
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return Json(new { isSucceeded = false, error_msg = e.Message });
            }
            return Json(new { isSucceeded = true, error_msg = string.Empty });
        }

        //
        // GET: /Service/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.LeadContactId = new SelectList(db.Contacts, "ContactId", "FirstName", service.LeadContactId);
            ViewBag.ContractParticipationTypeId = new SelectList(db.ContractParticipationTypes, "ContractParticipationTypeId", "ContractParticipationTypeName", service.ContractParticipationTypeId);
            ViewBag.ProgrammeId = new SelectList(db.Programmes, "ProgrammeId", "ProgrammeName", service.ProgrammeId);
            ViewBag.ReferralMethodId = new SelectList(db.ReferralMethods, "ReferralMethodId", "ReferralMethodName", service.ReferralMethodId);
            ViewBag.ServiceSubTypeId = new SelectList(db.ServiceSubTypes, "ServiceSubTypeId", "ServiceSubTypeName", service.ServiceSubTypeId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "ServiceTypeId", "ServiceTypeName", service.ServiceTypeId);
            return View(service);
        }

        //
        // POST: /Service/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LeadContactId = new SelectList(db.Contacts, "ContactId", "FirstName", service.LeadContactId);
            ViewBag.ContractParticipationTypeId = new SelectList(db.ContractParticipationTypes, "ContractParticipationTypeId", "ContractParticipationTypeName", service.ContractParticipationTypeId);
            ViewBag.ProgrammeId = new SelectList(db.Programmes, "ProgrammeId", "ProgrammeName", service.ProgrammeId);
            ViewBag.ReferralMethodId = new SelectList(db.ReferralMethods, "ReferralMethodId", "ReferralMethodName", service.ReferralMethodId);
            ViewBag.ServiceSubTypeId = new SelectList(db.ServiceSubTypes, "ServiceSubTypeId", "ServiceSubTypeName", service.ServiceSubTypeId);
            ViewBag.ServiceTypeId = new SelectList(db.ServiceTypes, "ServiceTypeId", "ServiceTypeName", service.ServiceTypeId);
            return View(service);
        }

        //
        // GET: /Service/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        //
        // POST: /Service/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }



    public class JsonFilter : ActionFilterAttribute
    {
        public string Param { get; set; }
        public Type JsonDataType { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.ContentType.Contains("application/json"))
            {
                string inputContent;
                using (var sr = new StreamReader(filterContext.HttpContext.Request.InputStream))
                {
                    inputContent = sr.ReadToEnd();
                }
                var result = JsonConvert.DeserializeObject(inputContent, JsonDataType);
                filterContext.ActionParameters[Param] = result;
            }
        }
    }
}