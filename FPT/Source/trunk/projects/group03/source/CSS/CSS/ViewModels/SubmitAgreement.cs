using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSS.ViewModels
{
    public class SubmitAgreement
    {
        public string Name { get; set; }
        public int AgreementNumber { get; set; }
        public int VariantNumber { get; set; }
    }
}