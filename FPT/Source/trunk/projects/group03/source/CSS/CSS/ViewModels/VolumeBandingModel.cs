using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSS.ViewModels
{
    public class VolumeBandingModel
    {
        public int RFONumber { get; set; }
        public string CustomerName { get; set; }
        public int? VolumeId { get; set; }
        public string TriggerCredit { get; set; }
        public string PayableTo { get; set; }
    }
}