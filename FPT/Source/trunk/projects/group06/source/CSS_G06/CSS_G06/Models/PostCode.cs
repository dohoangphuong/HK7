//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSS_G06.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PostCode()
        {
            this.RFOUsers = new HashSet<RFOUser>();
        }
    
        public int PostCodeId { get; set; }
        public string PostCode1 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFOUser> RFOUsers { get; set; }
    }
}