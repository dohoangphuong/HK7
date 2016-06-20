using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CSS.Models;
using CSS.ViewModels;
using System.Net.Mail;
using System.Net;

namespace CSS.Controllers
{
    public class AgreementController : Controller
    {
        private readonly CSSEntities1 _db = new CSSEntities1();

        #region Le Quang Nhat
        /// <summary>
        /// UC1: Agreement static for Homepage
        /// </summary>
        /// <returns>ParticialStatics view</returns>
        [ChildActionOnly]
        public ActionResult ParticialStatics()
        {
            if (Request.IsAuthenticated)
            {
                return View(_db.AgreementStatus.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// UC16: Show agreement static page
        /// </summary>
        /// <returns>Statics view</returns>
        public ActionResult Statics()
        {
            if (Request.IsAuthenticated)
            {
                List<Agreement> recentAgreement = _db.Agreements.Where(x => (x.CreatedBy == @User.Identity.Name || x.LastUpdatedBy == @User.Identity.Name)).OrderByDescending(x => x.LastUpdatedDate).Take(3).ToList();
                ViewBag.recentAgreement = recentAgreement;
                return View(_db.AgreementStatus.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// UC16: Direct after user choose view agreement
        /// </summary>
        /// <param name="select">format: AgreementNumber/VariantNumber</param>
        /// <returns>ViewAgreement view</returns>
        [HttpPost]
        public ActionResult Statics(string @select)
        {
            if (Request.IsAuthenticated)
            {
                if (@select != null)
                {
                    //"Select" = AgreementNumber/VariantNumber
                    string[] part = @select.Split('/');
                    return RedirectToAction("ViewAgreement", new { agreementNumber = part[0], variantNumber = part[1] });
                }
                else
                {
                    return RedirectToAction("Statics");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        /// <summary>
        /// UC3: Copy an agreement
        /// </summary>
        /// <param name="agreementNumber">AgreementNumber of selected agreement</param>
        /// <param name="variantNumber"></param>
        /// <returns>Copy agreement view</returns>
        public ActionResult Copy(int agreementNumber = 0, int variantNumber = 0)
        {
            if (Request.IsAuthenticated)
            {
                Agreement agreement = _db.Agreements.Find(agreementNumber, variantNumber);
                if (agreement == null)
                {
                    return HttpNotFound();
                }
                //new Variant = highest variant +1
                ViewBag.NewVariant = _db.Agreements.Where(x => x.AgreementNumber == agreement.AgreementNumber).OrderByDescending(x => x.VariantNumber).First().VariantNumber + 1;
                return View(agreement);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// UC3: Handle user choice in copy view
        /// </summary>
        /// <param name="agreement">Agreement model</param>
        /// <param name="choice">value of submit button to know which button user clicked</param>
        /// <returns>Edit or add view depend on user's choice</returns>
        [HttpPost]
        public ActionResult Copy(Agreement agreement, int choice)
        {
            if (Request.IsAuthenticated)
            {
                //Copy agreement infomation from database
                Agreement newAgreement = _db.Agreements.AsNoTracking().Single(x => x.AgreementNumber == agreement.AgreementNumber &&
                    x.VariantNumber == agreement.VariantNumber);
                //Update some new value
                newAgreement.CreatedBy = User.Identity.Name;
                newAgreement.CreatedDate = DateTime.Now;
                newAgreement.LastUpdatedBy = User.Identity.Name;
                newAgreement.LastUpdatedDate = DateTime.Now;
                newAgreement.LastStatusUpdatedDate = DateTime.Now;
                newAgreement.AuthorisedDate = null;
                newAgreement.AuthorisedBy = null;
                //Get all RFO User
                newAgreement.RFOUsers = _db.Agreements.Find(agreement.AgreementNumber, agreement.VariantNumber).RFOUsers;
                //New agreement status will be draft
                newAgreement.StatusId = 1;
                //Get all comment from selected agreement
                List<Comment> comments = _db.Comments.AsNoTracking().Where(x => x.AgreementNumber == agreement.AgreementNumber &&
                    x.VariantNumber == agreement.VariantNumber).ToList();
                //Get all credit note text from selected agreement
                List<CreditNoteText> creditNoteTexts = _db.CreditNoteTexts.AsNoTracking().Where(x => x.AgreementNumber == agreement.AgreementNumber &&
                    x.VariantNumber == agreement.VariantNumber).ToList();
                //Get Volume of agreement
                Volume volume = _db.Volumes.AsNoTracking().SingleOrDefault(x => x.VolumeId == agreement.VolumeId);

                switch (choice)
                {
                    //Duplicate this agreement with a new variant
                    case 1:
                        newAgreement.VariantNumber = _db.Agreements.Where(x => x.AgreementNumber == newAgreement.AgreementNumber).
                            OrderByDescending(x => x.VariantNumber).First().VariantNumber + 1;
                        newAgreement.RFONumbers = _db.Agreements.Find(agreement.AgreementNumber, agreement.VariantNumber).RFONumbers;
                        //Add volume into database and update volumeID for new agreement
                        if (volume != null)
                        {
                            _db.Volumes.Add(volume);
                            newAgreement.VolumeId = volume.VolumeId;
                        }
                        //Update comment reference and add to database
                        foreach (Comment comment in comments)
                        {
                            comment.VariantNumber = newAgreement.VariantNumber;
                            _db.Comments.Add(comment);
                        }
                        //Update credit note text reference and add to database
                        foreach (CreditNoteText creditNoteText in creditNoteTexts)
                        {
                            creditNoteText.VariantNumber = newAgreement.VariantNumber;
                            _db.CreditNoteTexts.Add(creditNoteText);
                        }
                        _db.Agreements.Add(newAgreement);
                        _db.SaveChanges();
                        return RedirectToAction("EditAgreement",
                                new { agreementNumber = newAgreement.AgreementNumber, variantNumber = newAgreement.VariantNumber });

                    //Duplicate this agreement agreement for a new agreement with...
                    case 2:
                        newAgreement.AgreementNumber = _db.Agreements.OrderByDescending(x => x.AgreementNumber).First().AgreementNumber + 1;
                        newAgreement.VariantNumber = 1;
                        newAgreement.RFONumbers = _db.Agreements.Find(agreement.AgreementNumber, agreement.VariantNumber).RFONumbers;
                        //Add volume indo db and update volumeID for new agreement
                        if (volume != null)
                        {
                            _db.Volumes.Add(volume);
                            newAgreement.VolumeId = volume.VolumeId;
                        }
                        //Update comment reference
                        foreach (Comment comment in comments)
                        {
                            comment.AgreementNumber = newAgreement.AgreementNumber;
                            comment.VariantNumber = newAgreement.VariantNumber;
                            _db.Comments.Add(comment);
                        }
                        //Update credit note text reference and add to database
                        foreach (CreditNoteText creditNoteText in creditNoteTexts)
                        {
                            creditNoteText.AgreementNumber = newAgreement.AgreementNumber;
                            creditNoteText.VariantNumber = newAgreement.VariantNumber;
                            _db.CreditNoteTexts.Add(creditNoteText);
                        }
                        _db.Agreements.Add(newAgreement);
                        _db.SaveChanges();
                        return RedirectToAction("EditAgreement",
                                new { agreementNumber = newAgreement.AgreementNumber, variantNumber = newAgreement.VariantNumber });

                    //Duplicate this agreement for a new customer
                    case 3:
                        newAgreement.RFONumbers.Clear();
                        newAgreement.Volume = volume;
                        newAgreement.Comments = comments;
                        newAgreement.CreditNoteTexts = creditNoteTexts;
                        TempData["newAgreement"] = newAgreement;
                        return RedirectToAction("AddNewAgreement");
                    //Something went wrong
                    default:
                        return View("Error");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// UC8: Approve a awaiting agreement
        /// </summary>
        /// <param name="agreementNumber">AgreementNumber of selected agreement</param>
        /// <param name="variantNumber"></param>
        /// <returns>View agreement screen</returns>
        [HttpPost]
        public ActionResult Approve(int agreementNumber, int variantNumber)
        {
            if (Request.IsAuthenticated)
            {
                //Find and check agreement in database
                Agreement agreement = _db.Agreements.Find(agreementNumber, variantNumber);
                if (agreement == null)
                {
                    return HttpNotFound();
                }

                //Check if status is "Awaiting approval"
                if (agreement.StatusId == 2)
                {
                    //Find status "Approved"
                    agreement.AgreementStatu = _db.AgreementStatus.Find(4);
                    //Update related fields
                    agreement.LastStatusUpdatedDate = DateTime.Now;
                    agreement.LastUpdatedBy = User.Identity.Name;
                    agreement.LastUpdatedDate = DateTime.Now;
                    _db.SaveChanges();
                }
                return RedirectToAction("ViewAgreement", new { agreementNumber = agreement.AgreementNumber, variantNumber = agreement.VariantNumber });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion

        #region "Nguyễn Trung Lâm"

        /// <summary>
        /// Search agreement
        /// </summary>
        /// <param name="statusId">statusId of selected agreement</param>
        /// <returns></returns>
        public ActionResult SearchAgreement(int? statusId)
        {
            if (Request.IsAuthenticated)
            {

                SearchAgreementModel searchmodel = new SearchAgreementModel();

                //initialize the default value of Dropdowlist status is statusId
                if (statusId != null) searchmodel.AgreementStatus.StatusId = statusId.Value;

                //Initialize for Dropdowlist CustomerType, Dropdowlist status, Dropdowlist csm
                ViewBag.ListCustomerType = _db.CustomerTypes.ToArray();
                ViewBag.ListStatus = _db.AgreementStatus.ToArray();

                ViewBag.ListCSM = (from usertype in _db.UserTypes
                                   from username in _db.RFOUsers
                                   where usertype.UserType1 == "CSM" && usertype.UserTypeId == username.UserTypeId
                                   select username).ToList().Select(c => new SelectListItem { Value = c.UserId.ToString(), Text = c.FirstName + " " + c.LastName });


                return View("SearchAgreement", searchmodel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        /// <summary>
        /// Search agreement
        /// </summary>
        /// <param name="model">input, what the user wants to search</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchAgreementResults(SearchAgreementModel model)
        {
            if (model != null)
            {
                //query search agreement 
                var results = (from agreement in _db.Agreements
                               from rfouser in _db.RFOUsers
                               from rfonumber1 in _db.RFONumbers
                               where (agreement.AgreementNumber == model.AgreementNumber || model.AgreementNumber == null) &&
                                     (agreement.RFONumbers.FirstOrDefault().RFONumber1 == rfonumber1.RFONumber1 && rfonumber1.Company.Name == model.Name || model.Name == null) &&
                                     (agreement.RFONumbers.FirstOrDefault().RFONumber1 == rfonumber1.RFONumber1 && rfonumber1.PostCode.Trim().ToLower() == model.PostCode.Trim().ToLower() || model.PostCode == null) &&
                                     (agreement.RFOUsers.FirstOrDefault().UserId == rfouser.UserId && rfouser.UserId.ToString() == model.CSM || model.CSM == null) &&
                                     (agreement.RFONumbers.FirstOrDefault().RFONumber1 == rfonumber1.RFONumber1 && rfonumber1.CustomerTypeId == model.CustomerType.CustomerTypeId || model.CustomerType.CustomerTypeId == null) &&
                                     (agreement.RFONumbers.FirstOrDefault().RFONumber1 == rfonumber1.RFONumber1 && rfonumber1.RFONumber1 == model.RFONumber || model.RFONumber == null) &&
                                     (agreement.AgreementStatu.StatusId == model.AgreementStatus.StatusId) &&
                                     (agreement.StartDate == model.StartDate || model.StartDate == null) &&
                                     (agreement.EndDate == model.EndDate || model.EndDate == null)
                               select new SearchAgreementModel
                               {
                                   RFONumber = agreement.RFONumbers.FirstOrDefault().RFONumber1,
                                   CustomerType = agreement.RFONumbers.FirstOrDefault().CustomerType,
                                   Name = agreement.RFONumbers.FirstOrDefault().Company.Name,
                                   PostCode = agreement.RFONumbers.FirstOrDefault().PostCode,
                                   CSM = agreement.RFOUsers.FirstOrDefault().FirstName + " " + agreement.RFOUsers.FirstOrDefault().LastName,
                                   AgreementStatus = agreement.AgreementStatu,
                                   StartDate = agreement.StartDate,
                                   EndDate = agreement.EndDate,
                                   AgreementNumber = agreement.AgreementNumber,
                                   VariantNumber = agreement.VariantNumber
                               }).Distinct();



                //if found, then take the results transmitted to the model 
                //if not found, then show message for user

                var searchResults = results.ToArray();

                if (searchResults.Any())
                {
                    return PartialView("SearchAgreementResults", searchResults);
                }
                else
                {
                    ViewBag.errorMessage = "Not Found!";
                    return PartialView("SearchAgreementResults", new SearchAgreementModel[0]);
                }

            }
            else
                return PartialView("SearchAgreementResults", new SearchAgreementModel[0]);
        }

        /// <summary>
        /// View an agreement
        /// </summary>
        /// <param name="agreementNumber">AgreementNumber of selected agreement</param>
        /// <param name="variantNumber">VariantNumber of selected agreement</param>
        /// <returns></returns>
        public ActionResult ViewAgreement(int? agreementNumber, int? variantNumber)
        {
            if (Request.IsAuthenticated)
            {
                if (agreementNumber == null || variantNumber == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    //find agreement has agreementnumber and variantnumber
                    Agreement agreement = _db.Agreements.Find(agreementNumber, variantNumber);

                    //set viewbag.status to install viewagreement screen
                    ViewBag.status = agreement.StatusId;

                    if (agreement.AgreementStatu.StatusId == 1)
                    {
                        return RedirectToAction("EditAgreement", new { agreementNumber, variantNumber });
                    }
                    else
                    {

                        return View(agreement);
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// View an agreement
        /// </summary>
        /// <param name="select">agreementnumber + variantNumber, which user want view</param>
        /// <param name="choice">select function of user </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SearchAgreement(string select, int choice)
        {
            if (Request.IsAuthenticated)
            {
                if (select != null)
                {
                    //split to agreementNumber and variantNumber
                    string[] part = select.Split('/');

                    switch (choice)
                    {
                        case 1:
                            //Audit
                            break;
                        case 2:
                            //Copy
                            return RedirectToAction("Copy", new { agreementNumber = part[0], variantNumber = part[1] });

                        case 3:
                            //View
                            return RedirectToAction("ViewAgreement", new { agreementNumber = part[0], variantNumber = part[1] });

                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("SearchAgreement");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Reject an agreement
        /// </summary>
        /// <param name="agreementNumber">agreementnumber of agreement select</param>
        /// <param name="variantNumber">variantNumber of agreement select </param>
        /// <returns></returns>
        public ActionResult RejectAgreement(int? agreementNumber, int? variantNumber)
        {
            if (Request.IsAuthenticated)
            {
                if (agreementNumber != null && variantNumber != null)
                {
                    //find agreemnt, which user want reject by agreementNumber and variantNumber
                    if (_db != null)
                    {
                        _db.Agreements.Find(agreementNumber, variantNumber);
                        var rejectModel = new RejectModel();

                        //find RFoNumber, which has relationship by agreementNumber and variantNumber
                        var querry = (from agreement in _db.Agreements
                                      from rfo in _db.RFONumbers
                                      where (agreement.RFONumbers.FirstOrDefault().RFONumber1 == rfo.RFONumber1 && agreement.AgreementNumber == agreementNumber &&
                                            agreement.VariantNumber == variantNumber)
                                      select rfo);

                        var rfoNumber = querry.ToArray();

                        if (rfoNumber.Any())
                        {

                            // intialize for rejectmodel to tranfer reject Agreement View
                            rejectModel.RFONumber = rfoNumber[0].RFONumber1;
                            rejectModel.AgreementNumber = agreementNumber;
                            rejectModel.VariantNumber = variantNumber;
                            rejectModel.CustormerName = rfoNumber[0].Company.Name;
                        }
                        else
                        {
                            return HttpNotFound();
                        }

                        return View(rejectModel);
                    }
                }
                else
                {
                    return HttpNotFound();
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return null;
        }

        /// <summary>
        /// Reject an agreement
        /// </summary>
        /// <param name="model">input of user</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RejectAgreement(RejectModel model)
        {
            if (model.Reason != null)
            {
                //find agreement by agreementNumber and variantNumber
                var agreementReject = _db.Agreements.Find(model.AgreementNumber, model.VariantNumber);

                //update agreemnt status to reject and update reject reason to comment
                var comment = new Comment();

                agreementReject.StatusId = 5;
                agreementReject.LastUpdatedBy = User.Identity.Name;
                agreementReject.LastUpdatedDate = DateTime.Now;
                agreementReject.LastStatusUpdatedDate = DateTime.Now;

                comment.AgreementNumber = model.AgreementNumber;
                comment.VariantNumber = model.VariantNumber;
                comment.DateTime = DateTime.Now;

                //status reject has id = 2
                comment.CommentTypeId = 2;

                agreementReject.Comments.Add(comment);

                _db.SaveChanges();

                return RedirectToAction("ViewAgreement", "Agreement", agreementReject);
            }
            return View(model);
        }

        #endregion

        #region NGUYEN HAI DANG

        /// Function call view AddAgreement
        /// 
        /// <returns>view AddNewAgreement</returns>
        public ActionResult AddNewAgreement()
        {
            //if (Request.IsAuthenticated)
            {
                //initialize for searchmodel
                SearchCustomerModel searchModel = new SearchCustomerModel();

                //get system config values
                ViewBag.CustomerTypes = _db.CustomerTypes.ToArray();
                ViewBag.BusinessArea = (from syscvt in _db.SYSCVTs
                                        join syscft in _db.SYSCFTs.Where(s => s.XSYSCONFIGNAME == "BUSINESS AREA")
                                        on syscvt.NSYSTEMCONFGID equals syscft.NSYSTEMCONFGID
                                        select syscvt)
                               .ToArray();

                //return view AddNewAgreement
                return View(searchModel);
            }
            //else
            //    return RedirectToAction("Index", "Home");
        }

        /// Funcion Create Agreement
        /// rfoNumber: Customer id
        /// return view EditAgreement
        public ActionResult CreateAgreement(int? rfoNumber)
        {
            if (Request.IsAuthenticated)
            {
                if (rfoNumber == null)
                    return HttpNotFound();

                //agreement number = last agreement number + 1
                Agreement agrmt = new Agreement();
                var lastAgrmtNumber = _db.Agreements.ToList().LastOrDefault();
                if (lastAgrmtNumber != null)
                    agrmt.AgreementNumber = lastAgrmtNumber.AgreementNumber + 1;
                else
                    agrmt.AgreementNumber = 1;

                //get status draft
                var agrmtStatus = _db.AgreementStatus.Single(s => string.Compare(s.AgreementStatus, "Draft", StringComparison.OrdinalIgnoreCase) == 0);
                if (agrmtStatus == null)
                    return HttpNotFound();
                else
                    agrmt.StatusId = 1;

                //find object RFoNumber
                var rfoObject = _db.RFONumbers.Find(rfoNumber);
                if (rfoObject == null)
                    return HttpNotFound();
                else
                    agrmt.RFONumbers.Add(rfoObject);

                //assign info to agreement
                agrmt.VariantNumber = 1;
                agrmt.SignReceived = true;
                agrmt.SignReceived = false;
                agrmt.AuthorisedBy = User.Identity.Name;
                agrmt.AuthorisedDate = DateTime.Now;
                agrmt.CreatedBy = User.Identity.Name;
                agrmt.CreatedDate = DateTime.Now;
                agrmt.LastStatusUpdatedDate = DateTime.Now;
                agrmt.LastUpdatedDate = DateTime.Now;
                //current user who is loging into system
                agrmt.LastUpdatedBy = User.Identity.Name;

                //default banding
                var banding = new Banding
                {
                    Min = 0,
                    Max = 100
                };
                //default volume
                Volume vol = new Volume();

                //save to database
                try
                {
                    vol.Bandings.Add(banding);
                    vol.Agreements.Add(agrmt);

                    //save them to database
                    _db.Bandings.Add(banding);
                    _db.Agreements.Add(agrmt);
                    _db.Volumes.Add(vol);
                    _db.SaveChanges();
                }
                catch
                {
                    return HttpNotFound();
                }

                //return view EditAgreement
                return RedirectToAction("EditAgreement", "Agreement", new { agrmt.AgreementNumber, agrmt.VariantNumber });
            }
            else
                return RedirectToAction("Index", "Home");
        }

        /// Function load AgreementModel
        /// agrmt: object Agreement
        /// return view EditAgreement
        public AgreementModel LoadAgreementModel(Agreement agrmt)
        {
            AgreementModel agrmtModel = new AgreementModel { ModelBasicDetail = new BasicDetailModel() };
            //basic detail model
            //query many to many relationship
            var rfoNumberObj = _db.RFONumbers.FirstOrDefault(rfo => rfo.Agreements
                .Any(agr => agr.AgreementNumber == agrmt.AgreementNumber
                    && agr.VariantNumber == agrmt.VariantNumber));
            if (rfoNumberObj == null)
                return null;
            agrmtModel.ModelBasicDetail.RFONumber = rfoNumberObj.RFONumber1;
            if (rfoNumberObj.Company != null)
                agrmtModel.ModelBasicDetail.CustomerName = rfoNumberObj.Company.Name;
            agrmtModel.ModelBasicDetail.AgreementNumber = agrmt.AgreementNumber;
            agrmtModel.ModelBasicDetail.VarriantNumber = agrmt.VariantNumber;
            agrmtModel.ModelBasicDetail.AgreementName = agrmt.Name;
            agrmtModel.ModelBasicDetail.AgeementDescription = agrmt.Description;

            //if startdate has value, assign it to currentdate, startdate of model
            if (agrmt.StartDate != null)
            {
                agrmtModel.ModelBasicDetail.CurrentDate = agrmt.StartDate.Value;
                agrmtModel.ModelBasicDetail.StartDate = agrmt.StartDate.Value;
            }
            //else assign current time of system to them
            else
            {
                agrmtModel.ModelBasicDetail.CurrentDate = DateTime.Now;
                agrmtModel.ModelBasicDetail.StartDate = DateTime.Now;
            }
            //if enddate has value, assign it to enddate of model
            if (agrmt.EndDate != null)
                agrmtModel.ModelBasicDetail.EndDate = agrmt.EndDate.Value;
            //if startdate has value, assign startdate with 90 days to enddate(90 will be an element)
            //else assign system time with 90 days to enddate
            else
            {
                agrmtModel.ModelBasicDetail.EndDate = agrmt.StartDate != null ? agrmt.StartDate.Value.AddDays(90) : DateTime.Now.AddDays(90);
            }
            if (agrmt.SignRequired != null)
                agrmtModel.ModelBasicDetail.SignRequired = agrmt.SignRequired.Value;
            //assign basic info
            if (agrmt.FundingMethod != null)
                agrmtModel.ModelBasicDetail.FundingMethodId = agrmt.FundingMethod.FundingMethodId
                    + "/" + agrmt.FundingMethod.SignedContractDefault;
            agrmtModel.ModelBasicDetail.PaymentTo = agrmt.PaymentTo;
            if (agrmt.HandlingCharge != null)
                agrmtModel.ModelBasicDetail.HandingCharge = agrmt.HandlingCharge.Value;
            agrmtModel.ModelBasicDetail.DealerVisibility = agrmt.DealerVisibility;
            agrmtModel.ModelBasicDetail.VolumeDiscountType = agrmt.VolumeDiscountType;
            agrmtModel.ModelBasicDetail.DiscountUnit = agrmt.DiscountUnit;
            agrmtModel.ModelBasicDetail.Combinability = agrmt.Combinability;

            //dealer selection model
            agrmtModel.ModelSearchDealer = new SearchDealerModel
            {
                AgreementNumber = agrmt.AgreementNumber,
                VarriantNumber = agrmt.VariantNumber
            };
            if (agrmt.RFOUsers != null)
            {
                //query many to many relationship
                var dealers = from rfo in agrmt.RFOUsers
                              from addr in _db.ContactAddresses.Where(ad => ad.UserId == rfo.UserId).Take(1)
                              select new DealerSelectionModel()
                              {
                                  Code = rfo.UserId,
                                  DealerName = rfo.FirstName + " " + rfo.LastName,
                                  Town = addr.Town,
                                  County = addr.County
                              };
                agrmtModel.ModelSearchDealer.ListDealer = dealers;
            }

            //molume banding model
            agrmtModel.ModelVolumeBanding = new VolumeBandingModel();
            if (agrmt.Volume != null)
            {
                agrmtModel.ModelVolumeBanding.VolumeId = agrmt.Volume.VolumeId;
                agrmtModel.ModelVolumeBanding.TriggerCredit = agrmt.Volume.TriggerCredit;
                agrmtModel.ModelVolumeBanding.PayableTo = agrmt.Volume.PaymentTo;
            }
            agrmtModel.ModelVolumeBanding.RFONumber = rfoNumberObj.RFONumber1;

            if (rfoNumberObj.Company != null)
                agrmtModel.ModelVolumeBanding.CustomerName = rfoNumberObj.Company.Name;

            //misc text model
            agrmtModel.ModelMiscText = new MiscTextModel
            {
                AgreementNumber = agrmt.AgreementNumber,
                VarriantNumber = agrmt.VariantNumber
            };
            var creditNote = agrmt.CreditNoteTexts.FirstOrDefault();
            if (creditNote != null)
                agrmtModel.ModelMiscText.CreditNoteText = creditNote.CreditNoteText1;
            //get comment has type "Internal Comment"
            var comment = agrmt.Comments.FirstOrDefault(c => c.CommentType.CommentType1 == "Internal Comment");
            if (comment != null)
                agrmtModel.ModelMiscText.CommentText = comment.Comment1;

            return agrmtModel;
        }

        /// Fucntion create parameters
        /// 
        /// 
        public void CreateParameters()
        {
            //get system config parameter from table SYSCVT and SYSCFT
            //funding method
            var fundingMethods = _db.FundingMethods.ToList();
            foreach (var fmethod in fundingMethods)
                fmethod.SignedContractDefault = fmethod.FundingMethodId + "/" + fmethod.SignedContractDefault;
            ViewBag.FundingMethodIds = fundingMethods;
            //paymento
            ViewBag.PaymentToes = _db.SYSCFTs.Find(1).SYSCVTs.ToList();
            //dealer visibility
            ViewBag.DealerVisibilities = _db.SYSCFTs.Find(2).SYSCVTs.ToList();
            //volumediscounttype
            ViewBag.VolumeDiscountTypes = _db.SYSCFTs.Find(11).SYSCVTs.ToList();
            //discountunit
            ViewBag.DiscountUnits = _db.SYSCFTs.Find(3).SYSCVTs.ToList();
            //combinability
            ViewBag.Combinabilities = _db.SYSCFTs.Find(4).SYSCVTs.ToList();
            //triggercredit
            ViewBag.TriggerCredits = _db.SYSCFTs.Find(5).SYSCVTs.ToList();
            //payebleto
            ViewBag.PayableToes = _db.SYSCFTs.Find(1).SYSCVTs.ToList();
        }

        /// Action edit agreeemnt
        /// AgreementNumber, VariantNumber: primary key of table Agreement
        /// return view EditAgreement
        public ActionResult EditAgreement(int? agreementNumber, int? variantNumber)
        {
            if (Request.IsAuthenticated)
            {
                //find agreement
                var agrmt = _db.Agreements.Find(agreementNumber, variantNumber);
                if (agrmt == null)
                    return HttpNotFound();

                //load agreement model
                var agrmtModel = LoadAgreementModel(agrmt);
                if (agrmtModel == null)
                    return HttpNotFound();

                //create parameters
                CreateParameters();

                //return view EditAgreement
                return View("EditAgreement", agrmtModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// Function Save Agreement Basic Details
        /// detail: BasicDetailModel
        /// return an alert
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult BasicDetails()
        {
            BasicDetailModel detail = new BasicDetailModel();
            if (TryUpdateModel(detail))
            {
                //find agreement
                var agrmnt = _db.Agreements.Find(detail.AgreementNumber, detail.VarriantNumber);
                if (agrmnt == null)
                {
                    ViewBag.errorMessage = "Agreement not found.";
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }
                agrmnt.Name = detail.AgreementName;
                agrmnt.Description = detail.AgeementDescription;
                agrmnt.StartDate = detail.StartDate;
                agrmnt.EndDate = detail.EndDate;

                //split string to get id value. Example: "1/Yes"
                string[] signedContract = detail.FundingMethodId.Split('/');
                int fundingMethodId;
                int.TryParse(signedContract[0], out fundingMethodId);
                agrmnt.FundingMethodId = fundingMethodId;
                agrmnt.PaymentTo = detail.PaymentTo;
                agrmnt.HandlingCharge = detail.HandingCharge;
                agrmnt.DealerVisibility = detail.DealerVisibility;
                agrmnt.DiscountUnit = detail.DiscountUnit;
                agrmnt.Combinability = detail.Combinability;
                agrmnt.VolumeDiscountType = detail.VolumeDiscountType;
                agrmnt.SignRequired = detail.SignRequired;
                agrmnt.LastStatusUpdatedDate = DateTime.Now;
                agrmnt.LastUpdatedDate = DateTime.Now;
                //current user who is loging into system
                agrmnt.LastUpdatedBy = User.Identity.Name;

                //save to database
                try
                {
                    _db.Entry(agrmnt).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.errorMessage = "Can not save agreement.\n" + ex.Message;
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }

                return PartialView("~/Views/Shared/Alert.cshtml");
            }
            else
            {
                ViewBag.errorMessage = "Can not receive input.";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }
        }

        /// Save MiscText
        /// mtModel: MiscTextModel
        /// return an alert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMiscText()
        {
            MiscTextModel mtModel = new MiscTextModel();
            if (TryUpdateModel(mtModel))
            {
                //find agreement
                var agrmt = _db.Agreements.Find(mtModel.AgreementNumber, mtModel.VarriantNumber);
                if (agrmt == null)
                {
                    ViewBag.errorMessage = "Can not find cagreement.";
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }

                //find commenttype
                var cmtType = _db.CommentTypes.First(c => c.CommentType1 == "Internal Comment");
                if (cmtType == null)
                {
                    ViewBag.errorMessage = "Can not comment type.";
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }

                //find creditnote for this agreement
                var creditNote = _db.CreditNoteTexts.FirstOrDefault(cr => cr.AgreementNumber == mtModel.AgreementNumber
                    && cr.VariantNumber == mtModel.VarriantNumber);
                CreditNoteText noteText = null;
                //if credit note text has value, assign infor for it
                if (creditNote != null)
                {
                    //create object CreditNoteText
                    creditNote.AgreementNumber = mtModel.AgreementNumber;
                    creditNote.VariantNumber = mtModel.VarriantNumber;
                    creditNote.CreditNoteText1 = mtModel.CreditNoteText;
                    creditNote.DateTime = DateTime.Now;
                }
                //else create new CreditNoteText
                else
                {
                    noteText = new CreditNoteText
                    {
                        AgreementNumber = mtModel.AgreementNumber,
                        VariantNumber = mtModel.VarriantNumber,
                        CreditNoteText1 = mtModel.CreditNoteText,
                        DateTime = DateTime.Now
                    };
                }

                //find comment for this agreement
                var cmt = _db.Comments
                    .FirstOrDefault(c => c.AgreementNumber == mtModel.AgreementNumber
                    && c.VariantNumber == mtModel.VarriantNumber
                    && c.CommentTypeId == cmtType.CommentTypeId);

                Comment comment = null;
                //if comment has value, assign infor for it
                if (cmt != null)
                {
                    cmt.AgreementNumber = mtModel.AgreementNumber;
                    cmt.VariantNumber = mtModel.VarriantNumber;
                    cmt.UserId = User.Identity.Name;
                    cmt.DateTime = DateTime.Now;
                    cmt.Comment1 = mtModel.CommentText;
                }
                //else create new comment
                else
                {
                    //create object Comment
                    comment = new Comment
                    {
                        AgreementNumber = mtModel.AgreementNumber,
                        VariantNumber = mtModel.VarriantNumber,
                        UserId = User.Identity.Name,
                        DateTime = DateTime.Now,
                        Comment1 = mtModel.CommentText,
                        CommentTypeId = cmtType.CommentTypeId
                    };
                }

                //save to database
                try
                {
                    if (creditNote != null)
                        _db.Entry(creditNote).State = System.Data.Entity.EntityState.Modified;
                    else
                    {
                        agrmt.CreditNoteTexts.Add(noteText);
                        _db.Entry(agrmt).State = System.Data.Entity.EntityState.Modified;
                    }
                    if (cmt != null)
                        _db.Entry(cmt).State = System.Data.Entity.EntityState.Modified;
                    else
                    {
                        agrmt.Comments.Add(comment);
                        if (_db.Entry(agrmt).State != System.Data.Entity.EntityState.Modified)
                            _db.Entry(agrmt).State = System.Data.Entity.EntityState.Modified;
                    }
                    _db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.errorMessage = "Can not save Agreement. " + ex.Message;
                    return PartialView("~/Views/Shared/Warning.cshtml");
                }
                return PartialView("~/Views/Shared/Alert.cshtml");
            }
            else
            {
                ViewBag.errorMessage = "Can not receive input.";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }

        }

        [HttpPost]
        public ActionResult UpdateConfirm(int? agreementNumber, int? variantNumber)
        {
            var agrmt = _db.Agreements.Find(agreementNumber, variantNumber);
            if (agrmt != null)
                return PartialView("Confirmation", agrmt);
            else
            {
                ViewBag.errorMessage = "Cannot update Confimation.";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }
        }

        [ChildActionOnly]
        public ActionResult RenderConfirmation(int? agreementNumber, int? variantNumber)
        {
            var agrmt = _db.Agreements.Find(agreementNumber, variantNumber);
            if (agrmt != null)
                return PartialView("Confirmation", agrmt);
            else
            {
                ViewBag.errorMessage = "Cannot update Confimation.";
                return PartialView("~/Views/Shared/Warning.cshtml");
            }
        }

        #endregion

        #region Do Hoang Phuong

        /// <summary>
        /// UC05: Extend an Agreement
        /// </summary>
        /// <param name="iAgreementNumber">AgreementNumber of selected agreement</param>
        /// <param name="iVariantNumber">VariantNumber of selected agreement</param>
        /// <returns>Extend Agreement</returns>
        /// <summary/>
        public ActionResult ExtendAgreement(int iAgreementNumber, int iVariantNumber)
        {
            ExtendAgreement extendModel = new ExtendAgreement();
            Agreement iAgr = _db.Agreements.Single(x => x.AgreementNumber == iAgreementNumber && x.VariantNumber == iVariantNumber);

            if (iAgr.RFONumbers.Count > 0)
                extendModel.RFONumber = iAgr.RFONumbers.First().RFONumber1;
            extendModel.Name = iAgr.Name;
            extendModel.AgreementNumber = iAgr.AgreementNumber;
            extendModel.VariantNumber = iAgr.VariantNumber;
            if (iAgr.StartDate != null)
                extendModel.StartDate = (DateTime)iAgr.StartDate;
            if (iAgr.EndDate != null)
                extendModel.EndDate = (DateTime)iAgr.EndDate;
            if (iAgr.StatusId != null) extendModel.StatusId = (int)iAgr.StatusId;

            return View(extendModel);
        }

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="iEmailTo">Email of Company</param>
        /// <param name="iSubject">subject of email</param>
        /// <param name="iBody"></param>
        /// <summary/>
        private void SendEmail(string iEmailTo, string iSubject, string iBody)
        {
            if (iEmailTo != null)
            {
                var smtpAddress = "smtp.mail.yahoo.com";
                var portNumber = 587;

                string emailFrom = "phuong_css@yahoo.com.vn";
                string password = "taikhoancss";
                string emailTo = iEmailTo;

                string subject = iSubject;
                string body = iBody;

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
        }

        /// <summary>
        /// UC05: Extend an Agreement
        /// </summary>
        /// <param name="extendModel">ExtendAgreement model</param>
        /// <param name="type">value of submit button to know which button user clicked</param>
        /// <returns>View Agreement</returns>
        /// <summary/>
        public ActionResult DisposeExtendAgreement(ExtendAgreement extendModel, int type)
        {
            Agreement currentAggreement = _db.Agreements.AsNoTracking().Single(x => x.AgreementNumber == extendModel.AgreementNumber && x.VariantNumber == extendModel.VariantNumber);
            Company companySendEmail = _db.Companies.Find(_db.Agreements.Find(extendModel.AgreementNumber, extendModel.VariantNumber).RFONumbers.First().CompanyId);

            if (type == 1)
            {
                var newAgreement = currentAggreement;
                if (newAgreement.StatusId == 4)//approved
                {
                    //------------Add new agreement------------
                    newAgreement.VariantNumber = _db.Agreements.Where(x => x.AgreementNumber == extendModel.AgreementNumber).OrderByDescending(x => x.VariantNumber).First().VariantNumber + 1;
                    newAgreement.StatusId = 1;
                    newAgreement.StartDate = extendModel.StartDate;
                    newAgreement.EndDate = extendModel.EndDate;
                    //add agreementRFO
                    newAgreement.RFONumbers = _db.Agreements.Find(extendModel.AgreementNumber, extendModel.VariantNumber).RFONumbers;


                    //------------send email------------
                    if (companySendEmail.Emailaddress != null)
                    {
                        string subject = "Hello, " + companySendEmail.Name + ".";
                        string body = "We have a message from the system to inform you: This system has been changed the Agreement status into 'Draft'(Base on Elements of the Agreement have AgreementNumber = "
                        + extendModel.AgreementNumber + " and VariantNumber = " + extendModel.VariantNumber + "). The system has been created a new variant based on the previous Agreement! (New Elements of Agreement are: AgreementNumber = "
                        + newAgreement.AgreementNumber + " and VariantNumber = " + newAgreement.VariantNumber + ")";

                        SendEmail(companySendEmail.Emailaddress, subject, body);
                    }

                    //------------discounts: Replace UC11------------
                    if (extendModel.EndDate < DateTime.Now)
                    {
                        // ------UC_11------
                        //int afterCharge = (int)NewAgreement.HandlingCharge - int.Parse(NewAgreement.DiscountUnit);
                        //if (afterCharge < 0)
                        //    afterCharge = 0;
                        //NewAgreement.HandlingCharge = afterCharge;
                    }

                    //------------save------------
                    _db.Agreements.Add(newAgreement);
                    _db.SaveChanges();
                }
            }

            //RedirectToAction: trả về hàm index-> để show ra trang chính
            return RedirectToAction("ViewAgreement", "Agreement", currentAggreement);
        }

        /// <summary>
        /// UC06: Terminate an Agreement
        /// </summary>
        /// <param name="iAgreementNumber">AgreementNumber of selected agreement</param>
        /// <param name="iVariantNumber">VariantNumber of selected agreement</param>
        /// <returns>View Agreement</returns>
        /// <summary/>
        public ActionResult TerminateAgreement(int iAgreementNumber, int iVariantNumber)
        {
            Agreement iAgr = _db.Agreements.Single(x => x.AgreementNumber == iAgreementNumber && x.VariantNumber == iVariantNumber);
            Company companySendEmail = _db.Companies.Find(_db.Agreements.Find(iAgreementNumber, iVariantNumber).RFONumbers.First().CompanyId);

            if (iAgr.StatusId == 4)
            {
                iAgr.StatusId = 6;//"Discontinued"
                _db.SaveChanges();

                //------------send email------------
                if (companySendEmail.Emailaddress != null)
                {
                    string subject = "Hello, " + companySendEmail.Name + ".";
                    string body = "We have a message from the system to inform you: This system has been changed! \n" + "The system has changed the Agreement status into 'Discontinued'.\n " +
                            "(Elements of Agreement are: AgreementNumber = " + iAgreementNumber + " and VariantNumber = " + iVariantNumber + ")";

                    SendEmail(companySendEmail.Emailaddress, subject, body);
                }
            }

            return RedirectToAction("ViewAgreement", "Agreement", iAgr);
        }

        /// <summary>
        /// UC07: Submit an Agreement
        /// </summary>
        /// <param name="iAgreementNumber">AgreementNumber of selected agreement</param>
        /// <param name="iVariantNumber">VariantNumber of selected agreement</param>
        /// <returns>Complete Agreement</returns>
        /// <summary/>
        public ActionResult CompleteAgreement(int iAgreementNumber, int iVariantNumber)
        {
            var iAgr = _db.Agreements.Single(x => x.AgreementNumber == iAgreementNumber && x.VariantNumber == iVariantNumber);
            var companySendEmail = _db.Companies.Find(_db.Agreements.Find(iAgreementNumber, iVariantNumber).RFONumbers.First().CompanyId);
            var submitAgreement = new SubmitAgreement
            {
                AgreementNumber = iAgreementNumber,
                VariantNumber = iVariantNumber
            };

            if (companySendEmail.Name != null)
            {
                submitAgreement.Name = companySendEmail.Name;
            }

            if (iAgr.StatusId == 1)//"Draft"
            {
                iAgr.StatusId = 2;//"Awaiting"
                _db.SaveChanges();
            }

            //------------send email------------
            if (companySendEmail.Emailaddress != null)
            {
                string subject = "Hello, " + companySendEmail.Name + ".";
                string body = "We have a message from the system to inform you: This system has been changed! \n" + "The system has changed the Agreement status into 'Awaiting'.\n " +
                            "(Elements of Agreement are: AgreementNumber = " + iAgreementNumber + " and VariantNumber = " + iVariantNumber + ")";

                SendEmail(companySendEmail.Emailaddress, subject, body);
            }

            return View(submitAgreement);
        }

        #endregion
    }
}