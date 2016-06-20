namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 10),
                        CourseNo = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 30, unicode: false),
                        Location = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        CourseId = c.String(nullable: false, maxLength: 10),
                        StudentId = c.String(nullable: false, maxLength: 10, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => new { t.CourseId, t.StudentId, t.Date })
                .ForeignKey("dbo.Student", t => t.StudentId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 10, unicode: false),
                        StudentNo = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollment", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            DropIndex("dbo.Enrollment", new[] { "CourseId" });
            DropTable("dbo.Student");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Course");
        }
    }
}
