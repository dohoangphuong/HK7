using ServicesDirectory.Models.DatabaseMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ServicesDirectory
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //Add sample data:
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            if (entities.ContractParticipationTypes.Count() == 0)
            {
                entities.ContractParticipationTypes.Add(new ContractParticipationType
                {
                    ContractParticipationTypeName = "Mandatory"
                });
                entities.ContractParticipationTypes.Add(new ContractParticipationType
                {
                    ContractParticipationTypeName = "Voluntary"
                });
                entities.ContractParticipationTypes.Add(new ContractParticipationType
                {
                    ContractParticipationTypeName = "Both"
                });
                entities.SaveChanges();
            }
            if (entities.ServiceSubTypes.Count() == 0)
            {
                entities.ServiceSubTypes.Add(new ServiceSubType
                {
                    ServiceSubTypeName = "Contract"
                });
                entities.ServiceSubTypes.Add(new ServiceSubType
                {
                    ServiceSubTypeName = "Independently Funded"
                });
                entities.SaveChanges();
            }
            if(entities.ContactTypes.Count() == 0)
            {
                entities.ContactTypes.Add(new ContactType
                {
                    ContactTypeName = "Employee"
                });
                entities.ContactTypes.Add(new ContactType
                {
                    ContactTypeName = "Client"
                });
                entities.ContactTypes.Add(new ContactType
                {
                    ContactTypeName = "Customers"
                });
                entities.SaveChanges();
            }
            if(entities.Contacts.Count() == 0)
            {
                ContactType contactType = (from d in entities.ContactTypes where d.ContactTypeName == "Employee" select d).FirstOrDefault();
                entities.Contacts.Add(new Contact
                {
                    FirstName = "Linh",
                    LastName = "Tran Khanh",
                    KnownAs = "TKL",
                    IsActive = true,
                    ContactTypeId = contactType.ContactTypeId
                });
                entities.Contacts.Add(new Contact
                {
                    FirstName = "Khanh",
                    LastName = "Nguyen Do Huu Duy",
                    KnownAs = "NDHDK",
                    IsActive = true,
                    ContactTypeId = contactType.ContactTypeId
                });
                entities.Contacts.Add(new Contact
                {
                    FirstName = "Tien",
                    LastName = "Hoang Tran Duy",
                    KnownAs = "HTDT",
                    IsActive = true,
                    ContactTypeId = contactType.ContactTypeId
                });
                try
                {
                    entities.SaveChanges();
                }
                catch(Exception e)
                {
                    int i = 2;
                }
            }
            if(entities.ServiceTypes.Count() == 0)
            {
                entities.ServiceTypes.Add(new ServiceType
                {
                    ServiceTypeName = "IT outsourcing"
                });
                entities.ServiceTypes.Add(new ServiceType
                {
                    ServiceTypeName = "Accounting outsourcing"
                });
                entities.ServiceTypes.Add(new ServiceType
                {
                    ServiceTypeName = "System maintaining"
                });
                entities.SaveChanges();
            }
            if(entities.ReferralMethods.Count() == 0)
            {
                entities.ReferralMethods.Add(new ReferralMethod
                {
                    ReferralMethodName = "Social network referral"
                });
                entities.ReferralMethods.Add(new ReferralMethod
                {
                    ReferralMethodName = "Professional referral"
                });
                entities.SaveChanges();
            }
            if(entities.RefDatas.Count() == 0)
            {
                foreach(string listCheckboxName in RefDataConstants.ServiceDetails_Details2_ListCheckboxName)
                {
                    RefData refData = new RefData
                        {
                            RefDataName = listCheckboxName.Replace(" ", ""),
                            RefDataValue = listCheckboxName
                        };
                    if (listCheckboxName == RefDataConstants.ServiceBenefitsCriterion)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.DisabilityLivingAllowance
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.EmploymentAndSupportAllowance
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.IncapabilityBenefit
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.IncomeSupport
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.JobSeekersAllowance
                        });
                    }
                    else if(listCheckboxName == RefDataConstants.ServiceBarriersCriterion)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.LoneParent
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.ESOL
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.Refugee
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.BasicSkills
                        });
                    }
                    else if(listCheckboxName == RefDataConstants.ServiceEthnicityCriterion)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.WhiteBritish
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.WhiteIrish
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.OtherWhite
                        });
                    }
                    else if(listCheckboxName == RefDataConstants.ServiceDisabilityCriterion)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.ChestBreathingProblems
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.ConditionRetrictingMobilityDexterity
                        });
                    }
                    else if (listCheckboxName == RefDataConstants.ServicePersonalCircumstancesCriterion)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.CarerResponsibilities
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.LoneParent2
                        });
                    }
                    else if (listCheckboxName == RefDataConstants.OtherServiceParticipationCriterion)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.ReferralToMainstreamServiceFirst
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.OnlyAccessServiceOnce
                        });
                    }
                    entities.RefDatas.Add(refData);

                }
                foreach(string item in RefDataConstants.ServiceDetails_Details3_ListCheckboxName)
                {
                    RefData refData = new RefData
                        {
                            RefDataName = item.Replace(" ", ""),
                            RefDataValue = item
                        };
                    if(item == RefDataConstants.ClientSupportProcess)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.Referral
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.InitialContact
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.PreEmployment
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.InWorkSupport
                        });
                    }
                    entities.RefDatas.Add(refData);

                }
                foreach(string item in RefDataConstants.ServiceDetails_Contract_ListCheckboxName)
                {
                    RefData refData = new RefData
                    {
                        RefDataName = item.Replace(" ", ""),
                        RefDataValue = item
                    };
                    if (item == RefDataConstants.ContractOutcome)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.ReferralsTaken
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.JobStarts
                        });
                    }
                    if (item == RefDataConstants.ContractObligation)
                    {
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.PhoneWeakly
                        });
                        refData.RefDataDetails.Add(new RefDataDetail
                        {
                            RefDataDetailValue = RefDataDetailConstants.EmailMonthly
                        });
                    }
                    entities.RefDatas.Add(refData);
                }
                entities.SaveChanges();
            }
        }
    }
}