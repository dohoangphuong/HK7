//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceDirectory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrganisationService
    {
        public int OrgID { get; set; }
        public int ServiceID { get; set; }
        public string Roles { get; set; }
    
        public virtual tblOrganisation tblOrganisation { get; set; }
        public virtual tblService tblService { get; set; }
    }
}
