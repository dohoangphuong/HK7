//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public Student()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }
    
        public int StudentNo { get; set; }
        public string StudentId { get; set; }
        public string StudentName { get; set; }
    
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
