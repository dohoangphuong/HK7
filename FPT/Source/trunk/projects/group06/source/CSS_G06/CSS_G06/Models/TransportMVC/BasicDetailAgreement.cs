using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSS_G06.Models
{
    public class BasicDetailAgreement
    {
        public int RFONumber { get; set; }
        public string CustomerName { get; set; }

        public string HandingCharge { get; set; }
        public Agreement DetailsAgreement { get; set; }

        
    }
}