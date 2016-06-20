﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ServiceDirectoryDBEntities : DbContext
    {
        public ServiceDirectoryDBEntities()
            : base("name=ServiceDirectoryDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Directorate> Directorates { get; set; }
        public virtual DbSet<GovOfficeRegion> GovOfficeRegions { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Premise> Premises { get; set; }
        public virtual DbSet<Programme> Programmes { get; set; }
        public virtual DbSet<ReferenceData> ReferenceDatas { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<SupportingMaterial> SupportingMaterials { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<TrustDistrict> TrustDistricts { get; set; }
        public virtual DbSet<TrustRegion> TrustRegions { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
