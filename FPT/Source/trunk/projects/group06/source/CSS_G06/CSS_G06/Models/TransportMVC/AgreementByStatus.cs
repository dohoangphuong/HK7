using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSS_G06.Models
{
    public class AgreementByStatus
    {
        public int AgreementNumber { get; set; }
        public int VariantNumber { get; set; }

        public string AgreementName { get; set; }
        public string CreateBy { get; set; }

        public bool IsEdit { get; set; }
    }
}