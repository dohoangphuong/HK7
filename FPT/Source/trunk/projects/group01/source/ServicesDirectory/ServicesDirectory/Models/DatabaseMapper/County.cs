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
    
    public partial class County
    {
        public County()
        {
            this.Departments = new HashSet<Department>();
            this.Directorates = new HashSet<Directorate>();
            this.GovOfficeRegion_County = new HashSet<GovOfficeRegion_County>();
            this.Organizations = new HashSet<Organization>();
            this.Premises = new HashSet<Premise>();
            this.Teams = new HashSet<Team>();
        }
    
        public int CountyId { get; set; }
        public string CountyName { get; set; }
    
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Directorate> Directorates { get; set; }
        public virtual ICollection<GovOfficeRegion_County> GovOfficeRegion_County { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Premise> Premises { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
