namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enrollment")]
    public partial class Enrollment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CourseId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string TraineeId { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "smalldatetime")]
        public DateTime DateEnrollment { get; set; }

        [StringLength(10)]
        public string FeedbackId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Feedback Feedback { get; set; }

        public virtual Trainee Trainee { get; set; }
    }
}
