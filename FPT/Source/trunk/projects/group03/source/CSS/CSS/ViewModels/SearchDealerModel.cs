﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSS.ViewModels
{
    public class SearchDealerModel
    {
        public int AgreementNumber { get; set; }
        public int VarriantNumber { get; set; }

        [Range(1, 99999999)]
        public int? Code { get; set; }

        [StringLength(50)]
        public string DealerName { get; set; }

        public IEnumerable<DealerSelectionModel> ListDealer { get; set; }
    }
}