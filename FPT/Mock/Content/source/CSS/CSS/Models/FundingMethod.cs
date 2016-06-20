//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class FundingMethod
    {
        public FundingMethod()
        {
            this.Agreements = new HashSet<Agreement>();
        }

        public int FundingMethodId { get; set; }

        [Required]
        [Display(Name = "Funding Method")]
        public string FundingMethodName { get; set; }

        [Display(Name = "Funding Type")]
        public string FundingType { get; set; }

        [Display(Name = "Contract Template")]
        public string ContractTemplateLocation { get; set; }

        [Display(Name = "Signed Contract Default")]
        public string SignedContractDefault { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public string AMISDeptCode { get; set; }

        public string AMISReasonCode { get; set; }

        [Display(Name = "Budget Code")]
        public string BudgetCode { get; set; }

        [Display(Name = "Cost Centre")]
        public string CostCentre { get; set; }

        [Display(Name = "Funding Method")]
        public string FileName { get; set; }
    
        public virtual ICollection<Agreement> Agreements { get; set; }
        public virtual BudgetCode BudgetCode1 { get; set; }
        public virtual CostCentre CostCentre1 { get; set; }
    }
}