//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Volume
    {
        public Volume()
        {
            this.Agreements = new HashSet<Agreement>();
            this.Bandings = new HashSet<Banding>();
        }
    
        public int VolumeId { get; set; }
        public string TriggerCredit { get; set; }
        public string PaymentTo { get; set; }
    
        public virtual ICollection<Agreement> Agreements { get; set; }
        public virtual ICollection<Banding> Bandings { get; set; }
    }
}