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
    
    public partial class Organization_RefDataDetail
    {
        public int Organization_RefDataDetailId { get; set; }
        public int OrganizationId { get; set; }
        public int RefDataDetailId { get; set; }
    
        public virtual Organization Organization { get; set; }
        public virtual RefDataDetail RefDataDetail { get; set; }
    }
}
