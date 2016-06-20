using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSS.ViewModels
{
    public class BasicDetailModel
    {
        public int RFONumber { get; set; }
        public string CustomerName { get; set; }
        public int AgreementNumber { get; set; }
        public int VarriantNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string AgreementName { get; set; }

        [Required]
        [StringLength(100)]
        public string AgeementDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CurrentDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public bool SignRequired { get; set; }
        public string FundingMethodId { get; set; }
        public string PaymentTo { get; set; }

        [Range(0, 1000000000)]
        public int HandingCharge { get; set; }
        public string DealerVisibility { get; set; }
        public string VolumeDiscountType { get; set; }
        public string DiscountUnit { get; set; }
        public string Combinability { get; set; }
    }
}