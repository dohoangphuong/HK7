using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSS.Models;

namespace CSS.ViewModels
{
    public class SearchAgreementModel
    {
        [DisplayName("RFO Number")]
        public int? RFONumber { get; set; }
        public CustomerType CustomerType { get; set; }
        [DisplayName("Custormer Name")]
        public string Name { get; set; }
        [MaxLength(10, ErrorMessage = "PostCode cannot be longer than 10 characters.")]
        public string PostCode { get; set; }
        public String Reason { get; set; }

        public String CSM { get; set; }
        public AgreementStatu AgreementStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [DisplayName("Agreement Number")]
        public int? AgreementNumber { get; set; }
        public int? VariantNumber { get; set; }

        [DisplayName("select")]
        public bool IsSelected { get; set; }

        public SearchAgreementModel()
        {
            CustomerType = new CustomerType();
            CSM = String.Empty;
            AgreementStatus = new AgreementStatu();
            Name = String.Empty;
            PostCode = String.Empty;
            IsSelected = false;
            Reason = string.Empty;

        }

    }
}
