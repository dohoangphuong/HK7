namespace TMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TMSContext : DbContext
    {
        public TMSContext()
            : base("name=TMSContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Course> DbCourse { get; set; }
        public virtual DbSet<Trainee> DbTrainee { get; set; }
        public virtual DbSet<Feedback> DbFeedback { get; set; }
        public virtual DbSet<Enrollment> DbEnrollment { get; set; }
        public virtual DbSet<FeedbackType> DbFeedbackType { get; set; }
        public virtual DbSet<FeedbackDetail> DbFeedbackDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(e => e.CourseId).IsUnicode(false);

            modelBuilder.Entity<Trainee>().Property(e => e.TraineeId).IsUnicode(false);
            modelBuilder.Entity<Trainee>().Property(e => e.Account).IsUnicode(false);


            modelBuilder.Entity<Feedback>()
                .HasMany<FeedbackDetail>(f => f.FeedbackDetails)
                .WithRequired(fd => fd.Feedback)
                .HasForeignKey(fd => fd.FeedbackId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedback>()
                .HasMany<Enrollment>(f => f.Enrollments)
                .WithOptional(e => e.Feedback)
                .HasForeignKey(e => e.FeedbackId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FeedbackType>()
                .HasMany<FeedbackDetail>(ft => ft.FeedbackDetails)
                .WithRequired(fd => fd.FeedbackType)
                .HasForeignKey(fd => fd.TypeNo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany<Enrollment>(c => c.Enrollments)
                .WithRequired(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainee>()
                .HasMany<Enrollment>(t => t.Enrollments)
                .WithRequired(e => e.Trainee)
                .HasForeignKey(e => e.TraineeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trainee>().MapToStoredProcedures();
        }
    }
}