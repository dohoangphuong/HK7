using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TMS.Models
{
    [Table("FeedbackDetail")]
    public partial class FeedbackDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string FeedbackId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int TypeNo { get; set; }

        [Required]
        public byte Rate { get; set; }

        public virtual Feedback Feedback { get; set; }

        public virtual FeedbackType FeedbackType { get; set; }
    }
}