using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicesDirectory.Models.DatabaseMapper;

namespace ServicesDirectory.Models.ViewModels
{
    public class ServiceDetailViewModel
    {
        public List<ServiceSubType> ServiceSubTypeList
        { get; set; }

        public List<Contact> ServiceContactList
        { get; set; }

        public List<ServiceType> ServiceTypeList
        { get; set; }

        public List<ReferralMethod> ReferralMethodList
        { get; set; }

        public Service Service
        { get; set; }

        public ServiceFunding ServiceFunding
        { get; set; }

        public List<RefDataDetailUI> BenefitsCriterionChildren
        { get; set; }

        public List<RefDataDetailUI> BarriersCriterionChildren
        { get; set; }

        public List<RefDataDetailUI> EthnicityCriterionChildren
        { get; set; }

        public List<RefDataDetailUI> DisabilityCriterionChildren
        { get; set; }

        public List<RefDataDetailUI> PersonalCircumstancesChildren
        { get; set; }

        public List<RefDataDetailUI> OtherServiceParticipationCriterionChildren
        { get; set; }

        public List<RefDataDetailUI> ClientSupportProcessChildren
        { get; set; }

        public List<RefDataDetailUI> ContractOutcomeChildren
        { get; set; }

        public List<RefDataDetailUI> ContractObligationChildren
        { get; set; }
    }
}