//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServicesDirectory.Models.DatabaseMapper
{
    using System;
    using System.Collections.Generic;
    
    public partial class BestContactMethod
    {
        public BestContactMethod()
        {
            this.Contacts = new HashSet<Contact>();
        }
    
        public int BestContactMethodId { get; set; }
        public string BestContactMethodName { get; set; }
    
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}