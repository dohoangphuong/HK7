//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.SupportingMaterials = new HashSet<SupportingMaterial>();
        }
    
        public int UserID { get; set; }
        public string Account { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string UserEmail { get; set; }
    
        public virtual ICollection<SupportingMaterial> SupportingMaterials { get; set; }
    }
}
