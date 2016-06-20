using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSS_G06.Models;

namespace CSS_G06.Controllers
{
    public class ViewAgreementController : Controller
    {
       [HttpGet]
        public ActionResult ViewAgreement_ReadOnly(int agreementNumber, int variantNumber)
        {
            SelectCustomer rsModel = new SelectCustomer();
            rsModel.AgreementNumber = agreementNumber;
            rsModel.AgreementVariant = variantNumber;
            using (var model = new CSSEntities())
            {
                // get agreement's basic information
                var agreement = model.Agreements.SingleOrDefault(agr =>
                   (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
                if (agreement == null)
                    throw new Exception("Cannot find agreement with agreement number = " + agreementNumber
                        + "and variant number = " + variantNumber);
                // get start - end date
                ViewBag.StartDate = ((agreement.StartDate != null) ? agreement.StartDate.Value.ToString("dd MMMM yyyy") : "");
                ViewBag.EndDate = ((agreement.EndDate != null) ? agreement.EndDate.Value.ToString("dd MMMM yyyy") : "");
                // get status
                var status = model.AgreementStatus.SingleOrDefault(stt => (stt.StatusId == agreement.StatusId)).AgreementStatus;
                ViewBag.AgreementStatus = status + "";
                // get business area
                var buisinessArea = model.Companies.SingleOrDefault(cpn => (cpn.RFONumbers.Any(rfo =>
                    rfo.Agreements.Any(agr => (agr.AgreementNumber == agreement.AgreementNumber &&
                        agr.VariantNumber == agreement.VariantNumber)))));
                ViewBag.BusinessArea = (buisinessArea == null) ? "" : buisinessArea.BusinessArea + "";
                // get name
                ViewBag.Name = agreement.Name + "";
                // get description
                ViewBag.Description = agreement.Description + "";
                // get create by
                ViewBag.CreatedBy = agreement.CreatedBy + "";
                // get create date
                ViewBag.CreatedDate = agreement.CreatedDate.ToString("dd MMMM yyyy") + "";
                // get authorsied by
                ViewBag.AuthorisedBy = agreement.AuthorisedBy + "";
                // get authorsied date
                ViewBag.AuthorisedDate = ((agreement.AuthorisedDate != null) ? agreement.AuthorisedDate.Value.ToString("dd MMMM yyyy") : "");
                // get signed received
                ViewBag.SignedReceived = (agreement.SignReceived == false)?"NO":"YES";
                // get signed received date
                ViewBag.SignedReceivedDate = ((agreement.SignReceivedDate != null) ? agreement.SignReceivedDate.Value.ToString("dd MMMM yyyy") : "");
                // get number of registrations
                ViewBag.NumberOfRegistrations = agreement.NumberOfRegistrations + "";
                // get AMIS Code
                ViewBag.AMISAccountCode = agreement.AMISAccountCode;
                // get lastest updated by
                ViewBag.LastestUpdatedBy = agreement.LastUpdatedBy + "";
                //get lastest updated date
                ViewBag.LastestUpdatedDate = agreement.LastStatusUpdatedDate.ToString("dd MMMM yyyy")+"";
                // get signed agreement required
                ViewBag.SignedRequired = (agreement.SignRequired == false) ? "NO" : "YES";
                // get combinability
                ViewBag.Combinability = agreement.Combinability + "";
                // get funding method
                var fundingMethod = model.FundingMethods.SingleOrDefault(fun =>(fun.FundingMethodId == agreement.FundingMethodId));
                ViewBag.FundingMethod = fundingMethod.FundingMethodName + "";
                //get payment to
                ViewBag.PaymentTo = agreement.PaymentTo + "";
                // get handing charge
                ViewBag.HandingCharge = agreement.HandlingCharge + "$";
                // get dealer visibility
                ViewBag.DealerVisibility = agreement.DealerVisibility + "";
                // get discount type
                ViewBag.DiscountUnit = agreement.DiscountUnit+"";
                // get agenda payment
                var agendaPayment = model.AgendaPayments.SingleOrDefault(agd => (agd.Agreements.Any(agr =>
                    (agr.AgreementNumber == agreement.AgreementNumber && agr.VariantNumber == agreement.VariantNumber))));
                ViewBag.AgendaPayment = (agendaPayment != null) ? agendaPayment.AgendaPayment1 + "" : "";
                // get all dealer
                List<ViewAgreementDealer> allDealerList = new List<ViewAgreementDealer>();
                var allDealer = (model.RFOUsers.Where(user => user.Agreements.Any(agr =>
                    agr.AgreementNumber == agreement.AgreementNumber && agr.VariantNumber == agreement.VariantNumber))).ToList();
                foreach (RFOUser dealer in allDealer)
                {
                    ViewAgreementDealer tmpDealer = new ViewAgreementDealer();
                    tmpDealer.DealerCode = dealer.UserId;
                    tmpDealer.DealerName = dealer.Title;
                    var contactAddress = model.ContactAddresses.SingleOrDefault(add => (add.UserId == dealer.UserId));
                    if(contactAddress == null)
                    {
                        tmpDealer.Town = "";
                        tmpDealer.Country = "";
                    }
                    else
                    {
                        tmpDealer.Town = contactAddress.Town + "";
                        tmpDealer.Country = contactAddress.Country + "";
                    }
                    allDealerList.Add(tmpDealer);
                }
                ViewBag.DealerList = allDealerList;
                // get credit note
                var creditNotes = (from credit in model.CreditNoteTexts
                                   where (credit.AgreementNumber == agreement.AgreementNumber &&
                                   credit.VariantNumber == agreement.VariantNumber)
                                   select credit
                                       ).ToList();
                string allCreditNotes = "";
                foreach (CreditNoteText creditNoteText in creditNotes)
                {
                    allCreditNotes += creditNoteText.CreditNoteText1 + "\r\n";
                }
                ViewBag.CreditNote = allCreditNotes;

                // get credit comment
                var creditComments = (from comment in model.Comments
                                      where (comment.AgreementNumber == agreement.AgreementNumber &&
                                      comment.VariantNumber == agreement.VariantNumber)
                                      select comment).ToList();
                string allCreditComments = "";
                foreach (Comment cmt in creditComments)
                {
                    allCreditComments += cmt.Comment1 + "\t\r\n"+cmt.UserId+"\r\n\r\n";
                }
                ViewBag.CreditComment = allCreditComments;

                // get customer's information
                var rfoNumber = model.RFONumbers.SingleOrDefault(rfo => (rfo.Agreements.Any(agr =>
                    (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber))));
                if (rfoNumber == null)
                {
                    ViewBag.RFONumber = "";
                    ViewBag.CustomerType = ""; 
                    ViewBag.CustomerName = "";
                    ViewBag.CustomerPostcode = "";
                    ViewBag.BusinessArea = "";
                    ViewBag.CustomerRegion = "";
                }
                else
                {
                    var customerType = model.CustomerTypes.SingleOrDefault(cust => (cust.CustomerTypeId == rfoNumber.CustomerTypeId));
                    ViewBag.CustomerType = customerType.CustomerType1 + ""; 
                    ViewBag.RFONumber = rfoNumber.RFONumber1;
                    ViewBag.CustomerName = rfoNumber.RFOName;
                    ViewBag.CustomerPostcode = rfoNumber.PostCode + "";
                    var company = model.Companies.SingleOrDefault(cpn => (cpn.CompanyId == rfoNumber.CompanyId));
                    ViewBag.BusinessArea = company.BusinessArea+"";
                    var companyAddress = model.CompanyAddresses.SingleOrDefault(add => (add.CompanyId == rfoNumber.CompanyId));
                    if(companyAddress == null)
                        ViewBag.CustomerRegion = "";
                    else
                    {
                        var region = model.Regions.SingleOrDefault(reg => (reg.RegionId == companyAddress.RegionId));
                        ViewBag.CustomerRegion = region.RegionName + "";
                    }
                }
                // get banding value
                var volume = model.Volumes.SingleOrDefault(vol => (vol.Agreements.Any(agr =>
                    (agr.AgreementNumber == agreement.AgreementNumber && agr.VariantNumber == agreement.VariantNumber))));
                if (volume == null)
                {
                    ViewBag.BandingValue = "N/A";
                    ViewBag.TriggerCredit = "N/A";
                    ViewBag.PayableTo = "N/A";
                }
                else
                {
                    var bading = model.Bandings.SingleOrDefault(ban => (ban.VolumeId == volume.VolumeId));
                    if (bading != null)
                    {
                        ViewBag.BandingValue = bading.Min + " - " + bading.Max;
                    }
                    else 
                    {
                        ViewBag.BandingValue = "N/A";
                    }
                    ViewBag.TriggerCredit = volume.TriggerCredit + "";
                    ViewBag.PayableTo = volume.PaymentTo + "";
                }
            }
            return View("ViewAgreement_ReadOnly",rsModel);
        }

       [HttpGet]
       public ActionResult ViewAgreementEdit(int agreementNumber, int variantNumber)
       {
           Session["UserName"] = "GaCon";
           Session["UserId"] = 1;
          
           SelectCustomer rsModel = new SelectCustomer();
           rsModel.AgreementNumber = agreementNumber;
           rsModel.AgreementVariant = variantNumber;
           using (var model = new CSSEntities())
           {
               // get agreement's basic information
               var agreement = model.Agreements.SingleOrDefault(agr =>
                  (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
               if (agreement == null)
                   throw new Exception("Cannot find agreement with agreement number = " + agreementNumber
                       + "and variant number = " + variantNumber);
               // get customer's information
               var rfoNumber = model.RFONumbers.SingleOrDefault(rfo => (rfo.Agreements.Any(agr =>
                   (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber))));
               if (rfoNumber == null)
               {
                   ViewBag.RFONumber = "";
                   ViewBag.CustomerType = "";
                   ViewBag.CustomerName = "";
                   ViewBag.CustomerPostcode = "";
                   ViewBag.BusinessArea = "";
                   ViewBag.CustomerRegion = "";
               }
               else
               {
                   var customerType = model.CustomerTypes.SingleOrDefault(cust => (cust.CustomerTypeId == rfoNumber.CustomerTypeId));
                   ViewBag.CustomerType = customerType.CustomerType1 + "";
                   ViewBag.RFONumber = rfoNumber.RFONumber1;
                   ViewBag.CustomerName = rfoNumber.RFOName;
                   ViewBag.CustomerPostcode = rfoNumber.PostCode + "";
                   var company = model.Companies.SingleOrDefault(cpn => (cpn.CompanyId == rfoNumber.CompanyId));
                   ViewBag.BusinessArea = company.BusinessArea + "";
                   var companyAddress = model.CompanyAddresses.SingleOrDefault(add => (add.CompanyId == rfoNumber.CompanyId));
                   if (companyAddress == null)
                       ViewBag.CustomerRegion = "";
                   else
                   {
                       var region = model.Regions.SingleOrDefault(reg => (reg.RegionId == companyAddress.RegionId));
                       ViewBag.CustomerRegion = region.RegionName + "";
                   }
               }
           }
           return View("ViewAgreementEdit", rsModel);
       }

       [HttpGet]
       public ActionResult ViewAgreementEdit_BasicDetail(int agreementNumber, int variantNumber)
        {
            try
            {
                BasicDetailAgreement resultModel = new BasicDetailAgreement();
                Agreement agreement;
                using (var model = new CSSEntities())
                {
                    agreement = model.Agreements.SingleOrDefault(agr => (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
                    if (agreement == null)
                        throw new Exception("Cannot find agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'!");
                    else
                    {
                        List<RFONumber> rfonumbers = agreement.RFONumbers.ToList();
                        if(rfonumbers.Count < 1)
                            throw new Exception("Cannot find customer for agreement with number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'!");
                        resultModel.RFONumber = rfonumbers[0].RFONumber1;
                        resultModel.CustomerName = rfonumbers[0].RFOName;
                        resultModel.HandingCharge = ((long)(agreement.HandlingCharge)) + "";
                    }
                }
                resultModel.DetailsAgreement = agreement;

                using (var model = new CSSEntities())
                {
                    var fundingMethod = model.FundingMethods.ToList();
                    ViewBag.FundingMethod = fundingMethod;

                    var paymentTo = model.SystemConfigValues.Where(sys => (sys.SystemConfigId == 1)).ToList();
                    ViewBag.PaymentTo = paymentTo;

                    var agendaPayment = model.AgendaPayments.ToList();
                    ViewBag.AgendaPayment = agendaPayment;

                    var dealerVisibility = model.SystemConfigValues.Where(sys => (sys.SystemConfigId == 2)).ToList();
                    ViewBag.DealerVisibility = dealerVisibility;

                    var volumeDiscountType = model.SystemConfigValues.Where(sys => (sys.SystemConfigId == 11)).ToList();
                    ViewBag.VolumeDiscountType = volumeDiscountType;

                    var discountUnit = model.SystemConfigValues.Where(sys => (sys.SystemConfigId == 3)).ToList();
                    ViewBag.DiscountUnit = discountUnit;

                    var combinability = model.SystemConfigValues.Where(sys => (sys.SystemConfigId == 4)).ToList();
                    ViewBag.Combinability = combinability;
                }
                return PartialView("ViewAgreementEdit_BasicDetail", resultModel);
            }
            catch (Exception ex)
            {
                //throw ex;
                return null;
            }
        }

        [HttpPost]
        public ActionResult BasicAgreementSaveAsDraft(BasicDetailAgreement basicDetailAgreement)
        {
           string msg = "";
            try 
            {
                SaveAgreementAsDraft(basicDetailAgreement.DetailsAgreement,basicDetailAgreement.HandingCharge);
                msg = "Success! Saved the agreement to database as a draft agreement.";
            }
            catch (Exception ex) 
            {
                msg = "Failed! Cannot saved the agreement. Error as "+ex.Message;
            }
            ViewBag.Message = msg;
            return PartialView("ViewAgreementEdit_SaveAgreementResult");
           
        }

        [HttpGet]
        public ActionResult ViewAgreementEdit_SelectDealer(int agreementNumber, int variantNumber)
        {
            SearchDealer rsModel = new SearchDealer();
            rsModel.AgreementNumber = agreementNumber;
            rsModel.VariantNumber = variantNumber;
            using (var model = new CSSEntities())
            {
                var agreement = model.Agreements.SingleOrDefault(agr =>
                    (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
                if (agreement == null)
                {
                    //
                }
                else
                {
                    string dealerSelected = "";
                    var allDealer = (model.RFOUsers.Where(user => user.Agreements.Any(agr =>
                    agr.AgreementNumber == agreement.AgreementNumber && agr.VariantNumber == agreement.VariantNumber))).ToList();
                    foreach (RFOUser dealer in allDealer)
                    {
                        dealerSelected += ", " + dealer.UserId;
                    }
                    if (dealerSelected.Length > 0)
                        dealerSelected = dealerSelected.Remove(0, 1);
                    ViewBag.DealerSelected = dealerSelected;
                }
            }
            return PartialView("ViewAgreementEdit_SelectDealer", rsModel);
        }

        [HttpPost]
        public ActionResult SelectAplicableDealerSearch(SearchDealer searchUser)
        {
            if (ModelState.IsValid)
            {
                List<DealerResult> allResult;
                int dealerCode = 0;
                int.TryParse(searchUser.DealerCode, out dealerCode);
                List<RFOUser> allDealerAgreement;
                using (var model = new CSSEntities())
                {
                    allResult = (from user in model.RFOUsers
                                 join type in model.UserTypes on user.UserTypeId equals type.UserTypeId
                                 join address in model.ContactAddresses on user.UserId equals address.UserId
                                 where ((user.UserId == dealerCode || dealerCode < 1)
                                        && ((user.Title).Contains(searchUser.DealerName) || searchUser.DealerName == null)
                                        && (type.UserType1 == "Dealer"))
                                 select new DealerResult()
                                 {
                                     DealerCode = user.UserId,
                                     DealerName = user.Title,
                                     Town = address.Town,
                                     County = address.County,
                                 }).ToList();
                    allDealerAgreement = model.RFOUsers.Where(user => (user.Agreements.Any(agr =>
                        (agr.AgreementNumber == searchUser.AgreementNumber && agr.VariantNumber == searchUser.VariantNumber)))).ToList();

                }
                for (int i = 0; i < allResult.Count; i++)
                {
                    bool isavailbled = false;
                    foreach (RFOUser user in allDealerAgreement)
                    {
                        if (allResult[i].DealerCode == user.UserId && allResult[i].DealerName == user.Title)
                        {
                            isavailbled = true;
                            break;
                        }
                    }
                    if (isavailbled)
                    {
                        allResult.RemoveAt(i--);
                    }
                }
                if (allResult == null)
                    allResult = new List<DealerResult>();
                ViewBag.SumResult = allResult.Count;
                return PartialView("ViewAgreementEdit_SearchResultDaler", allResult);
            }
            else
            {
                List<DealerResult> allResult = new List<DealerResult>();
                return PartialView("ViewAgreementEdit_SearchResultDaler", allResult);
            }

        }

        [HttpGet]
        public ActionResult SaveDealer(int agreementNumber, int variantNumber, string selectDealer)
        {
            try
            {
                Agreement updateAgreement;
                string msg = "Success save dealer: ";
                using (var model = new CSSEntities())
                {
                    updateAgreement = model.Agreements.SingleOrDefault(agr => (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
                    if (updateAgreement == null)
                    {
                        throw new Exception("Cannot find agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'!");
                    }
                    selectDealer = selectDealer.Replace(',', ' ');
                    selectDealer = selectDealer.Replace("  ", " ");
                    string[] all = selectDealer.Split(new char[] { ' ' });
                    List<RFOUser> allUser = new List<RFOUser>();
                    for (int i = 0; i < all.Length; i++)
                    {
                        if (i > 1)
                        {
                            int dealerCode = -1;
                            int.TryParse(all[i], out dealerCode);
                            if (dealerCode > 0)
                            {
                                RFOUser dealer;
                                dealer = model.RFOUsers.SingleOrDefault(user => (user.UserId == dealerCode));

                                if (dealer != null)
                                {
                                    var listDealerAvailabeled = model.RFOUsers.Where(user => (user.Agreements.Any(agr
                                        => agr.AgreementNumber == updateAgreement.AgreementNumber && agr.VariantNumber == updateAgreement.VariantNumber))).ToList();
                                    if (listDealerAvailabeled == null || listDealerAvailabeled.Count == 0)
                                    {
                                        updateAgreement.RFOUsers.Add(dealer);
                                        msg += " " + dealer.UserId;
                                    }
                                    else
                                    {
                                        bool isAvialabled = false;
                                        foreach(RFOUser user in listDealerAvailabeled)
                                        {
                                            if (user.UserId == dealer.UserId)
                                            {
                                                isAvialabled = true;
                                                break;
                                            }
                                        }
                                        if (!isAvialabled)
                                        {
                                            updateAgreement.RFOUsers.Add(dealer);
                                            msg += " " + dealer.UserId;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    model.Entry(updateAgreement).State = System.Data.Entity.EntityState.Modified;
                    model.SaveChanges();
                }
                msg += " for agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'!";
                return Json(msg, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string msg = "Failed to save agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'! Error as " + ex.Message;

                return Json(msg, "application/json", JsonRequestBehavior.AllowGet);
            }
        }

       [HttpGet]
        public ActionResult ViewAgreementEdit_BandingVolume(int agreementNumber, int variantNumber)
       {

           using (var model = new CSSEntities())
           {
               var triggerCreditList = (from trigger in model.SystemConfigValues
                                        where trigger.SystemConfigId == 5
                                        select trigger).ToList();
               ViewBag.TriggerCredit = triggerCreditList;

               var payableToList = (from trigger in model.SystemConfigValues
                                    where trigger.SystemConfigId == 1
                                    select trigger).ToList();
               ViewBag.PayableTo = payableToList;

               Agreement agreement = model.Agreements.SingleOrDefault(agr => (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
               if(agreement == null)
               {
                   // 
               }
               else
               {
                   RFONumber rfoNumber = new RFONumber();
                   rfoNumber = model.RFONumbers.SingleOrDefault(rfo => (rfo.Agreements.Any(agr =>
                       (agr.AgreementNumber == agreement.AgreementNumber && agr.VariantNumber == agreement.VariantNumber))));
                   if (rfoNumber != null)
                   {
                       ViewBag.RFONumber = rfoNumber.RFONumber1;
                       ViewBag.CustomerName = rfoNumber.RFOName;
                   }
                   var volume = model.Volumes.SingleOrDefault(vol => (vol.Agreements.Any(agr =>
                       (agr.AgreementNumber == agreement.AgreementNumber && agr.VariantNumber == agreement.VariantNumber))));
                   if (volume != null)
                   {
                       ViewBag.CurrentTriggerCredit = volume.TriggerCredit;
                       ViewBag.CurrentPayableTo = volume.PaymentTo;
                       var banding = model.Bandings.SingleOrDefault(ban => (ban.VolumeId == volume.VolumeId));
                       if (banding != null)
                           ViewBag.CurrentBandingValue = banding.Min + " - " + banding.Max;
                   }
               }
           }
           VolumeBandingModel rsmodel = new VolumeBandingModel();
           rsmodel.AgreementNumber = agreementNumber;
           rsmodel.VariantNumber = variantNumber;
           return PartialView("ViewAgreementEdit_BandingVolume", rsmodel);
       }

       [HttpPost]
       public ActionResult ViewAgreement_AddBandingValue(List<int> resultBandingValue)
       {
           List<DefineBanding> allBanding = new List<DefineBanding>();
           if (resultBandingValue != null)
           {
               for (int i = 0; i < resultBandingValue.Count; i++)
               {
                   DefineBanding newBanding = new DefineBanding();
                   newBanding.ShowString = resultBandingValue[i++] + " - " + resultBandingValue[i];
                   allBanding.Add(newBanding);
               }
           }
           return PartialView("ViewAgreementEdit_EditVolumeBanding", allBanding);
       }

       [HttpGet]
       public ActionResult SaveBandingValue(int agreementNumber, int variantNumber, string triggerCredit, string payableTo,
           int min, int max)
       {
           try
           {
               AgreementStatu status;
               using (var model = new CSSEntities())
               {
                   var agreement = model.Agreements.SingleOrDefault(agr => (agr.VariantNumber == variantNumber && agr.AgreementNumber == agreementNumber));
                   if (agreement == null)
                       throw new Exception("Cannot find agreement with agreement number ='" + agreementNumber + " and variant number ='" + variantNumber);
                   status = model.AgreementStatus.SingleOrDefault(stt => (stt.AgreementStatus == "Draft"));
                   if (status == null)
                       throw new Exception("Cannot find agreement status as name 'Draft'. Please, check again!");
                   var numberList = (from config in model.SystemConfigValues
                                     where config.SystemConfigId == 19
                                     orderby config.SystemConfigValueId
                                     select config.Order).ToList();
                   int volumeId = 0;
                   if (numberList.Count > 0)
                       volumeId = numberList[0] + 1;
                   else
                       throw new Exception("Cannot find config value to created volume id");
                   Volume volume = new Volume();
                   volume.VolumeId = volumeId;
                   volume.TriggerCredit = triggerCredit;
                   volume.PaymentTo = payableTo;
                   model.Volumes.Add(volume);

                   var numberList1 = (from config in model.SystemConfigValues
                                      where config.SystemConfigId == 20
                                      orderby config.SystemConfigValueId
                                      select config.Order).ToList();
                   int bandingId = 0;
                   if (numberList.Count > 0)
                       bandingId = numberList1[0] + 1;
                   else
                       throw new Exception("Cannot find config value to created banding id");
                   Banding banding = new Banding();
                   banding.BandingId = bandingId;
                   banding.VolumeId = volume.VolumeId;
                   banding.Min = min;
                   banding.Max = max;

                   model.Bandings.Add(banding);
                   agreement.VolumeId = volume.VolumeId;

                   model.Entry(agreement).State = System.Data.Entity.EntityState.Modified;
                   model.SaveChanges();

               }
               return Json("Success! Saved the banding volume for agreement with agreement number = "
                   + agreementNumber + " and variant number = " + variantNumber
                   , "application/json", JsonRequestBehavior.AllowGet);

           }
           catch (Exception ex)
           {
               return Json("Fialed to save the banding volume for agreement with agreement number = "
                   + agreementNumber + " and variant number = " + variantNumber + ". Error as " + ex.Message
                   , "application/json", JsonRequestBehavior.AllowGet);
           }
       }

       [HttpGet]
       public ActionResult ViewAgreementEdit_MiscText(int agreementNumber, int variantNumber)
       {
           InputMiscText rsModel = new InputMiscText();
           rsModel.AgreementNumber = agreementNumber;
           rsModel.VariantNumber = variantNumber;
           using (var model = new CSSEntities())
           {
               // get agreement's basic information
               var agreement = model.Agreements.SingleOrDefault(agr =>
                  (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
               if (agreement == null)
                   throw new Exception("Cannot find agreement with agreement number = " + agreementNumber
                       + "and variant number = " + variantNumber);
               // get credit note
               var creditNotes = (from credit in model.CreditNoteTexts
                                  where (credit.AgreementNumber == agreement.AgreementNumber &&
                                  credit.VariantNumber == agreement.VariantNumber)
                                  select credit
                                      ).ToList();
               string allCreditNotes = "";
               foreach (CreditNoteText creditNoteText in creditNotes)
               {
                   allCreditNotes += creditNoteText.CreditNoteText1 + "\r\n";
               }
              rsModel.CreditNote = allCreditNotes;

               // get credit comment
               var creditComments = (from comment in model.Comments
                                     where (comment.AgreementNumber == agreement.AgreementNumber &&
                                     comment.VariantNumber == agreement.VariantNumber)
                                     select comment).ToList();
               string allCreditComments = "";
               foreach (Comment cmt in creditComments)
               {
                   allCreditComments += cmt.Comment1 + "\t\r\n" + cmt.UserId + "\r\n\r\n";
               }
               rsModel.Comment = allCreditComments;
           }


           return PartialView("ViewAgreementEdit_MiscText", rsModel);
       }
       [HttpGet]
       public ActionResult SaveMiscText(int agreementNumber, int variantNumber, string comment, string credit)
       {
           try
           {
               Agreement updateAgreement;
               using (var model = new CSSEntities())
               {
                   updateAgreement = model.Agreements.SingleOrDefault(agr => (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
                   if (updateAgreement == null)
                   {
                       throw new Exception("Cannot find agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'!");
                   }
                   if (comment != null || comment != "")
                   {
                       var numberList = (from config in model.SystemConfigValues
                                         where config.SystemConfigId == 21
                                         orderby config.SystemConfigValueId
                                         select config.Order).ToList();
                       int commentId = 0;
                       if (numberList.Count > 0)
                           commentId = numberList[0] + 1;
                       else
                           throw new Exception("Cannot find config value to created comment id");
                       Comment saveComment = new Comment();
                       int userId = -1;
                       int.TryParse(Session["UserId"] + "", out userId);
                       if (userId < 1)
                           throw new Exception("Cannot find user to created comment");
                       saveComment.CommentId = commentId;
                       saveComment.AgreementNumber = agreementNumber;
                       saveComment.VariantNumber = variantNumber;
                       saveComment.CommentTypeId = 1;
                       saveComment.Comment1 = comment;
                       saveComment.UserId = userId;
                       saveComment.DateTime = DateTime.Now;

                       model.Comments.Add(saveComment);

                   }
                   var numberList1 = (from config in model.SystemConfigValues
                                      where config.SystemConfigId == 22
                                      orderby config.SystemConfigValueId
                                      select config.Order).ToList();
                   int creditId = 0;
                   if (numberList1.Count > 0)
                       creditId = numberList1[0] + 1;
                   else
                       throw new Exception("Cannot find config value to created credit not id");
                   CreditNoteText saveCredit = new CreditNoteText();
                   saveCredit.CreditNoteTextId = creditId;
                   saveCredit.CreditNoteText1 = credit;
                   saveCredit.AgreementNumber = agreementNumber;
                   saveCredit.VariantNumber = variantNumber;
                   saveCredit.DateTime = DateTime.Now;

                   model.CreditNoteTexts.Add(saveCredit);

                   model.Entry(updateAgreement).State = System.Data.Entity.EntityState.Modified;
                   model.SaveChanges();
               }
               string msg = "Success save misc text for agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'!";
               return Json(msg, "application/json", JsonRequestBehavior.AllowGet);
           }
           catch (Exception ex)
           {
               string msg = "Failed to save misc text for agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'! Error as " + ex.Message;

               return Json(msg, "application/json", JsonRequestBehavior.AllowGet);
           }
       }

       [HttpGet]
       public ActionResult ViewAgreementEdit_Confirmation(int agreementNumber, int variantNumber)
       {
           ConfirmationModel rsModel = new ConfirmationModel();
           rsModel.AgreementNumber = agreementNumber;
           rsModel.VariantNumber = variantNumber;

           using (var model = new CSSEntities())
           {
               // get agreement's basic information
               var agreement = model.Agreements.SingleOrDefault(agr =>
                  (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
               if (agreement == null)
                   throw new Exception("Cannot find agreement with agreement number = " + agreementNumber
                       + "and variant number = " + variantNumber);
               // get start - end date
               ViewBag.StartEnd = ((agreement.StartDate != null) ? agreement.StartDate.Value.ToString("dd MMMM yyyy") : "")
                   + " - " + ((agreement.EndDate != null) ? agreement.EndDate.Value.ToString("dd MMMM yyyy") : "");
               // get status
               var status = model.AgreementStatus.SingleOrDefault(stt => (stt.StatusId == agreement.StatusId)).AgreementStatus;
               ViewBag.Status = status + "";
               // get business area
               var buisinessArea = model.Companies.SingleOrDefault(cpn => (cpn.RFONumbers.Any(rfo =>
                   rfo.Agreements.Any(agr => (agr.AgreementNumber == agreement.AgreementNumber &&
                       agr.VariantNumber == agreement.VariantNumber)))));
               ViewBag.BusinessArea = (buisinessArea == null) ? "" : buisinessArea.BusinessArea + "";
               // get name
               ViewBag.Name = agreement.Name + "";
               // get description
               ViewBag.Description = agreement.Description + "";
               // get create by
               ViewBag.CreateBy = agreement.CreatedBy + "";
               // get create date
               ViewBag.CreateDate = agreement.CreatedDate.ToString("dd MMMM yyyy") + "";
               // get authorsied by
               ViewBag.AuthorisedBy = agreement.AuthorisedBy + "";
               // get authorsied date
               ViewBag.AuthorisedDate = ((agreement.AuthorisedDate != null) ? agreement.AuthorisedDate.Value.ToString("dd MMMM yyyy") : "");
               // get signed agreement required
               ViewBag.SignedAgreementRequired = (agreement.SignRequired == false) ? "NO" : "YES";
               // get combinability
               ViewBag.Combinability = agreement.Combinability + "";
               //get payment to
               ViewBag.PaymentTo = agreement.PaymentTo + "";
               // get handing charge
               ViewBag.HandingCharge = agreement.HandlingCharge + "";
               // get agenda payment
               var agendaPayment = model.AgendaPayments.SingleOrDefault(agd => (agd.Agreements.Any(agr =>
                   (agr.AgreementNumber == agreement.AgreementNumber && agr.VariantNumber == agreement.VariantNumber))));
               ViewBag.AgendaPayment = (agendaPayment != null) ? agendaPayment.AgendaPayment1 + "" : "";
               // get all dealer
               var allDealer = (model.RFOUsers.Where(user => user.Agreements.Any(agr =>
                   agr.AgreementNumber == agreement.AgreementNumber && agr.VariantNumber == agreement.VariantNumber))).ToList();
               ViewBag.DealerCodeList = allDealer;
               // get credit note
               var creditNotes = (from credit in model.CreditNoteTexts
                                  where (credit.AgreementNumber == agreement.AgreementNumber &&
                                  credit.VariantNumber == agreement.VariantNumber)
                                  select credit
                                      ).ToList();
               string allCreditNotes = "";
               foreach (CreditNoteText creditNoteText in creditNotes)
               {
                   allCreditNotes += creditNoteText.CreditNoteText1 + "\r\n";
               }
               ViewBag.CreditNote = allCreditNotes;

               // get customer's information
               var rfoNumber = model.RFONumbers.SingleOrDefault(rfo => (rfo.Agreements.Any(agr =>
                   (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber))));
               if (rfoNumber == null)
               {
                   ViewBag.RFONumber = "";
                   ViewBag.CustomerName = "";
               }
               else
               {
                   ViewBag.RFONumber = rfoNumber.RFONumber1;
                   ViewBag.CustomerName = rfoNumber.RFOName;
               }
           }
           return PartialView("ViewAgreementEdit_Confirmation", rsModel);
       }
       [HttpGet]
       public ActionResult ViewAgreementEdit_ModelSupport(int agreementNumber, int variantNumber)
       {
           VolumeBandingModel rsmodel = new VolumeBandingModel();
           rsmodel.AgreementNumber = agreementNumber;
           rsmodel.VariantNumber = variantNumber;
           return PartialView("ViewAgreementEdit_ModelSupport", rsmodel);
       }

       private bool SaveAgreementAsDraft(Agreement agreement, string handingCharge)
       {
           try
           {
               Agreement agreementUpdate;
               using (var model = new CSSEntities())
               {
                   agreementUpdate = model.Agreements.SingleOrDefault(agr => (agr.AgreementNumber == agreement.AgreementNumber
                           && agr.VariantNumber == agreement.VariantNumber));
                   if (agreementUpdate == null)
                   {
                       throw new Exception("Cannot find agreement with agreement number = '" + agreement.AgreementNumber + "' and variant number = '" + agreement.VariantNumber + "'!");
                   }
                   AgreementStatu status;
                   status = model.AgreementStatus.SingleOrDefault(stt => (stt.AgreementStatus == "Draft"));
                   if (status == null)
                   {
                       throw new Exception("Cannot find agreement status as 'Draft'!");
                   }
                   int handingCharged1 = 0;
                   handingCharge = handingCharge.Replace(" ", "");
                   int.TryParse(handingCharge, out handingCharged1);

                   agreementUpdate.StatusId = status.StatusId;
                   agreementUpdate.LastStatusUpdatedDate = DateTime.Now;
                   agreementUpdate.LastUpdatedBy = Session["UserName"].ToString();
                   if (agreement.Name != null && agreement.Name != "" && agreementUpdate.Name != agreement.Name)
                   {
                       agreementUpdate.Name = agreement.Name;

                   }
                   if (agreement.Description != null && agreement.Description != "" && agreementUpdate.Description != agreement.Description)
                   {
                       agreementUpdate.Description = agreement.Description;
                   }
                   if (agreement.StartDate != null && agreement.EndDate != null)
                   {
                       if (agreement.StartDate != agreementUpdate.StartDate)
                           agreementUpdate.StartDate = agreement.StartDate;
                       if (agreement.EndDate != agreementUpdate.EndDate)
                           agreementUpdate.EndDate = agreement.EndDate;
                   }
                   if (agreement.SignRequired != agreementUpdate.SignRequired)
                   {
                       agreementUpdate.SignRequired = agreement.SignRequired;
                   }
                   if (agreement.FundingMethodId != null && agreement.FundingMethodId > 0 && agreement.FundingMethodId != agreementUpdate.FundingMethodId)
                   {
                       agreementUpdate.FundingMethodId = agreement.FundingMethodId;
                   }
                   if (agreement.PaymentTo != null && agreement.PaymentTo != "" && agreementUpdate.PaymentTo != agreement.PaymentTo)
                   {
                       agreementUpdate.PaymentTo = agreement.PaymentTo;
                   }
                   if (agreement.AgendaPaymentId != null && agreement.AgendaPaymentId > 0 && agreement.AgendaPaymentId != agreementUpdate.AgendaPaymentId)
                   {
                       agreementUpdate.AgendaPaymentId = agreement.AgendaPaymentId;
                   }
                   if (handingCharged1 >= 0 && handingCharged1 != agreementUpdate.HandlingCharge)
                   {
                       agreementUpdate.HandlingCharge = handingCharged1;
                   }
                   if (agreement.DealerVisibility != null && agreement.DealerVisibility != "" && agreementUpdate.DealerVisibility != agreement.DealerVisibility)
                   {
                       agreementUpdate.DealerVisibility = agreement.DealerVisibility;
                   }
                   if (agreement.DiscountUnit != null && agreement.DiscountUnit != "" && agreementUpdate.DiscountUnit != agreement.DiscountUnit)
                   {
                       agreementUpdate.DiscountUnit = agreement.DiscountUnit;
                   }
                   if (agreement.Combinability != null && agreement.Combinability != "" && agreementUpdate.Combinability != agreement.Combinability)
                   {
                       agreementUpdate.Combinability = agreement.Combinability;
                   }
                   model.Entry(agreementUpdate).State = System.Data.Entity.EntityState.Modified;
                   model.SaveChanges();
               }

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       [HttpGet]
       public ActionResult SubmitSaveAgreement(int agreementNumber, int variantNumber)
       {
           try
           {
               Agreement updateAgreement;
               using (var model = new CSSEntities())
               {
                   updateAgreement = model.Agreements.SingleOrDefault(agr => (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
                   if (updateAgreement == null)
                   {
                       throw new Exception("Cannot find agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'!");
                   }
                   updateAgreement.StatusId = 2; // Awaiting Approval
                   updateAgreement.LastStatusUpdatedDate = DateTime.Now;

                   model.Entry(updateAgreement).State = System.Data.Entity.EntityState.Modified;
                   model.SaveChanges();
               }
               string msg = "Success updated status for agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "' as 'Awaiting Approval'!";
               return Json(msg, "application/json", JsonRequestBehavior.AllowGet);
           }
           catch (Exception ex)
           {
               string msg = "Failed to save updated status agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'! Error as " + ex.Message;

               return Json(msg, "application/json", JsonRequestBehavior.AllowGet);
           }
       }

       [HttpGet]
       public ActionResult SubmitSaveAsDraftAgreement(int agreementNumber, int variantNumber)
       {
           try
           {
               Agreement updateAgreement;
               using (var model = new CSSEntities())
               {
                   updateAgreement = model.Agreements.SingleOrDefault(agr => (agr.AgreementNumber == agreementNumber && agr.VariantNumber == variantNumber));
                   if (updateAgreement == null)
                   {
                       throw new Exception("Cannot find agreement with agreement number = '" + agreementNumber + "' and variant number = '" + variantNumber + "'!");
                   }
                   updateAgreement.StatusId = 1; // Draft
                   updateAgreement.LastStatusUpdatedDate = DateTime.Now;

                   model.Entry(updateAgreement).State = System.Data.Entity.EntityState.Modified;
                   model.SaveChanges();
               }
               string msg = "Success saved as draft for agreement with agreement number = " + agreementNumber + " and variant number = " + variantNumber + "!";
               return Json(msg, "application/json", JsonRequestBehavior.AllowGet);
           }
           catch (Exception ex)
           {
               string msg = "Failed to save save as draft for agreement with agreement number = " + agreementNumber + " and variant number = " + variantNumber + "! Error as " + ex.Message;

               return Json(msg, "application/json", JsonRequestBehavior.AllowGet);
           }
       }

    }
}