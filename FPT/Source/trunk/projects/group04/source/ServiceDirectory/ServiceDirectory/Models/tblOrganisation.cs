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
    using System.ComponentModel.DataAnnotations;
    
    public partial class tblOrganisation
    {
        public tblOrganisation()
        {
            this.tblDirectorates = new HashSet<tblDirectorate>();
            this.tblOrganisationServices = new HashSet<tblOrganisationService>();
            this.tblPremises = new HashSet<tblPremis>();
            this.tblSupportingMaterials = new HashSet<tblSupportingMaterial>();
            this.tblProgrammes = new HashSet<tblProgramme>();
            this.tblReferenceDatas = new HashSet<tblReferenceData>();
        }
    
        public int OrgID { get; set; }
        public Nullable<int> ContactID { get; set; }
        public Nullable<int> AddressID { get; set; }
        public Nullable<int> BusinessID { get; set; }

        [Required(ErrorMessage="Please input the organisation name!")]
        [StringLength(200, ErrorMessage="Organisation name is not more than 200 characters!")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "Please input the short description!")]
        [StringLength(1000, ErrorMessage = "Short description is not more than 1000 characters!")]
        public string ShortDescription { get; set; }

        [StringLength(2000, ErrorMessage = "Full description is not more than 2000 characters!")]
        public string FullDescription { get; set; }

        [StringLength(20, ErrorMessage = "Phone number is not more than 20 characters!")]
        public string PhoneNumber { get; set; }

        [StringLength(20, ErrorMessage = "Fax is not more than 20 characters!")]
        public string Fax { get; set; }

        [StringLength(200, ErrorMessage = "Email is not more than 200 characters!")]
        public string Email { get; set; }

        [StringLength(200, ErrorMessage = "Web address description is not more than 200 characters!")]
        public string WebAddress { get; set; }
        public Nullable<int> CharityNumber { get; set; }
        public Nullable<int> CompanyNumber { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [Required(ErrorMessage = "Please input the address line 1!")]
        [StringLength(200, ErrorMessage = "Address line 1 is not more than 200 characters!")]
        public string AddressLine1 { get; set; }
        [StringLength(200, ErrorMessage = "Address line 2 is not more than 200 characters!")]
        public string AddressLine2 { get; set; }
        [StringLength(200, ErrorMessage = "Address line 3 is not more than 200 characters!")]
        public string AddressLine3 { get; set; }
        public Nullable<bool> Preferred { get; set; }
    
        public virtual tblAddress tblAddress { get; set; }
        public virtual tblBusinessType tblBusinessType { get; set; }
        public virtual tblContact tblContact { get; set; }
        public virtual ICollection<tblDirectorate> tblDirectorates { get; set; }
        public virtual ICollection<tblOrganisationService> tblOrganisationServices { get; set; }
        public virtual ICollection<tblPremis> tblPremises { get; set; }
        public virtual ICollection<tblSupportingMaterial> tblSupportingMaterials { get; set; }
        public virtual ICollection<tblProgramme> tblProgrammes { get; set; }
        public virtual ICollection<tblReferenceData> tblReferenceDatas { get; set; }
    }
}