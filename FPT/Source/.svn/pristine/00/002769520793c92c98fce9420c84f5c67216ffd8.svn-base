using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSS.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CSS.ViewModels
{
    public class SearchCustomerModel
    {
        [Range(1, 99999999)]
        public int? RFONumber { get; set; }

        public CustomerType SelectedCustomerType { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10)]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "{0} must be Alpha Numeric only.")]
        public string PostCode { get; set; }

        public string BusinessArea { get; set; }

        [DisplayName("select")]
        public bool? IsSelected { get; set; }

        public SearchCustomerModel()
        {
            SelectedCustomerType = new CustomerType();
        }
    }
}