namespace CMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class CSMContext : DbContext
    {
        public CSMContext()
            : base("name=CSMContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Student> DbStudent { get; set; }
        public virtual DbSet<Course> DbCourse { get; set; }
        public virtual DbSet<Enrollment> DbEnrollment { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<Student>().Property(e => e.StudentId).IsUnicode(false);
            mb.Entity<Course>().Property(e => e.CourseName).IsUnicode(false);

            mb.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithRequired(e => e.Student)
                .HasForeignKey(s => s.StudentId)
                .WillCascadeOnDelete(false);

            mb.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithRequired(e => e.Course)
                .HasForeignKey(c => c.CourseId)
                .WillCascadeOnDelete(false);
        }
    }

    [Table("Student")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentNo { get; set; }

        [Key]
        [StringLength(10)]
        public string StudentId { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentName { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }
    }

    [Table("Course")]
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseNo { get; set; }

        [Key]
        [StringLength(10)]
        public string CourseId { get; set; }

        [Required]
        [StringLength(30)]
        public string CourseName { get; set; }

        [StringLength(10)]
        public string Location { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }
    }

    [Table("Enrollment")]
    public class Enrollment
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CourseId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string StudentId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

        public Enrollment()
        { }

        public Enrollment(string courseId, string studentId)
        {
            CourseId = courseId;
            StudentId = studentId;
        }
    }
}