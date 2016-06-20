using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSS.ViewModels
{
    public class RejectModel
    {
        public int? RFONumber { get; set; }

        [DisplayName("Customer Name")]
        public String CustormerName { get; set; }
        [DisplayName("Agreement Number")]
        public int? AgreementNumber { get; set; }
        public int? VariantNumber { get; set; }

        [Required]
        [StringLength(200)]
        public String Reason { get; set; }


        public RejectModel()
        {
            CustormerName = String.Empty;
            Reason = String.Empty;
        }
    }
}