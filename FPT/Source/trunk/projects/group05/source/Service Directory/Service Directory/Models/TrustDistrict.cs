//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service_Directory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TrustDistrict
    {
        public int TrustDistrictID { get; set; }
        public Nullable<int> TrustRegionID { get; set; }
        public string TrustDistrictName { get; set; }
        public string TrustDistrictShortDescription { get; set; }
        public Nullable<bool> TrustDistrictIsActive { get; set; }
    
        public virtual TrustRegion TrustRegion { get; set; }
    }
}
