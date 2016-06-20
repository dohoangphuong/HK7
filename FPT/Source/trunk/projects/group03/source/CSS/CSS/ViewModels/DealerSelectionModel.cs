﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSS.Models;
using System.ComponentModel;

namespace CSS.ViewModels
{
    public class DealerSelectionModel
    {
        public int Code { get; set; }
        public string DealerName { get; set; }
        public string Town { get; set; }
        public string County { get; set; }

        [DisplayName("select")]
        public bool IsSelected { get; set; }

        public DealerSelectionModel() { }
    }
}