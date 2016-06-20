namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseNo { get; set; }

        [Key]
        [Required]
        [StringLength(10)]
        public string CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
