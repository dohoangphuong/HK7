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
    
    public partial class Contact
    {
        public Contact()
        {
            this.Contact1 = new HashSet<Contact>();
            this.Departments = new HashSet<Department>();
            this.Directorates = new HashSet<Directorate>();
            this.Organizations = new HashSet<Organization>();
            this.Programmes = new HashSet<Programme>();
            this.Services = new HashSet<Service>();
            this.ServiceFundings = new HashSet<ServiceFunding>();
            this.Teams = new HashSet<Team>();
        }
    
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string KnownAs { get; set; }
        public string OfficePhone { get; set; }
        public string MobilePhone { get; set; }
        public string STHomePhone { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<int> ManagerContactId { get; set; }
        public int ContactTypeId { get; set; }
        public Nullable<int> BestContactMethodId { get; set; }
        public string JobRole { get; set; }
        public string WorkBase { get; set; }
        public string JobTitle { get; set; }
        public bool IsActive { get; set; }
    
        public virtual BestContactMethod BestContactMethod { get; set; }
        public virtual ICollection<Contact> Contact1 { get; set; }
        public virtual Contact Contact2 { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Directorate> Directorates { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Programme> Programmes { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<ServiceFunding> ServiceFundings { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
