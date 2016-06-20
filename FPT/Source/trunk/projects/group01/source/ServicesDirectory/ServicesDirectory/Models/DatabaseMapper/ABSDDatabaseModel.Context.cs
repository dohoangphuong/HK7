﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ABSDDatabaseEntities : DbContext
    {
        public ABSDDatabaseEntities()
            : base("name=ABSDDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BestContactMethod> BestContactMethods { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<ContractParticipationType> ContractParticipationTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Directorate> Directorates { get; set; }
        public DbSet<FundingSource> FundingSources { get; set; }
        public DbSet<GovOfficeRegion> GovOfficeRegions { get; set; }
        public DbSet<GovOfficeRegion_County> GovOfficeRegion_County { get; set; }
        public DbSet<LocationStatu> LocationStatus { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Organization_Programme> Organization_Programme { get; set; }
        public DbSet<Organization_RefDataDetail> Organization_RefDataDetail { get; set; }
        public DbSet<OrganizationRoleType> OrganizationRoleTypes { get; set; }
        public DbSet<Premise> Premises { get; set; }
        public DbSet<Premise_LocationType> Premise_LocationType { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<RefData> RefDatas { get; set; }
        public DbSet<RefDataDetail> RefDataDetails { get; set; }
        public DbSet<ReferralMethod> ReferralMethods { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Service_Organization_OrganizationRoleType> Service_Organization_OrganizationRoleType { get; set; }
        public DbSet<Service_Premise> Service_Premise { get; set; }
        public DbSet<Service_RefDataDetail> Service_RefDataDetail { get; set; }
        public DbSet<ServiceFunding> ServiceFundings { get; set; }
        public DbSet<ServiceSubType> ServiceSubTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<SupportingMaterial> SupportingMaterials { get; set; }
        public DbSet<SupportingMaterialType> SupportingMaterialTypes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TrustDistrict> TrustDistricts { get; set; }
        public DbSet<TrustRegion> TrustRegions { get; set; }
        public DbSet<TypeOfBusiness> TypeOfBusinesses { get; set; }
    }
}
