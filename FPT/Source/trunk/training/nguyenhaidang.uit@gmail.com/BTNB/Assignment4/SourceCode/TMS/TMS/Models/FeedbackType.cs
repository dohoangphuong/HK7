namespace TMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedbackType")]
    public partial class FeedbackType
    {
        public FeedbackType()
        {
            FeedbackDetails = new HashSet<FeedbackDetail>();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<FeedbackDetail> FeedbackDetails { get; set; }
    }
}
