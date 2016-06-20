namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public Feedback()
        {
            FeedbackDetails = new HashSet<FeedbackDetail>();
            Enrollments = new HashSet<Enrollment>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackNo { get; set; }

        [Key]
        [Required]
        [StringLength(10)]
        public string FeedbackId { get; set; }

        [Required]
        public bool Complete { get; set; }

        public virtual ICollection<FeedbackDetail> FeedbackDetails { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
