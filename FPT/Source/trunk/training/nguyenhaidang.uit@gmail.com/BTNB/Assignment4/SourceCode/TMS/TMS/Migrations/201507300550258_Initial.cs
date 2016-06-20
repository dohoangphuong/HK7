namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 10, unicode: false),
                        CourseNo = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 10, unicode: false),
                        TraineeId = c.String(nullable: false, maxLength: 10, unicode: false),
                        DateEnrollment = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        FeedbackId = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => new { t.CourseId, t.TraineeId, t.DateEnrollment })
                .ForeignKey("dbo.Feedback", t => t.FeedbackId)
                .ForeignKey("dbo.Trainee", t => t.TraineeId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.TraineeId)
                .Index(t => t.FeedbackId);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        FeedbackId = c.String(nullable: false, maxLength: 10),
                        FeedbackNo = c.Int(nullable: false, identity: true),
                        Complete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackId);
            
            CreateTable(
                "dbo.FeedbackDetail",
                c => new
                    {
                        FeedbackId = c.String(nullable: false, maxLength: 10),
                        TypeNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FeedbackId, t.TypeNo })
                .ForeignKey("dbo.FeedbackType", t => t.TypeNo)
                .ForeignKey("dbo.Feedback", t => t.FeedbackId)
                .Index(t => t.FeedbackId)
                .Index(t => t.TypeNo);
            
            CreateTable(
                "dbo.FeedbackType",
                c => new
                    {
                        TypeNo = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        Rate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TypeNo);
            
            CreateTable(
                "dbo.Trainee",
                c => new
                    {
                        TraineeId = c.String(nullable: false, maxLength: 10, unicode: false),
                        TraineeNo = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        Account = c.String(nullable: false, maxLength: 20, unicode: false),
                        Password = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.TraineeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "TraineeId", "dbo.Trainee");
            DropForeignKey("dbo.FeedbackDetail", "FeedbackId", "dbo.Feedback");
            DropForeignKey("dbo.FeedbackDetail", "TypeNo", "dbo.FeedbackType");
            DropForeignKey("dbo.Enrollment", "FeedbackId", "dbo.Feedback");
            DropIndex("dbo.FeedbackDetail", new[] { "TypeNo" });
            DropIndex("dbo.FeedbackDetail", new[] { "FeedbackId" });
            DropIndex("dbo.Enrollment", new[] { "FeedbackId" });
            DropIndex("dbo.Enrollment", new[] { "TraineeId" });
            DropIndex("dbo.Enrollment", new[] { "CourseId" });
            DropTable("dbo.Trainee");
            DropTable("dbo.FeedbackType");
            DropTable("dbo.FeedbackDetail");
            DropTable("dbo.Feedback");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Course");
        }
    }
}
