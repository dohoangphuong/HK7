namespace CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_att_date : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Enrollment");
            AddPrimaryKey("dbo.Enrollment", new[] { "CourseId", "StudentId" });
            DropColumn("dbo.Enrollment", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollment", "Date", c => c.DateTime(nullable: false, storeType: "smalldatetime"));
            DropPrimaryKey("dbo.Enrollment");
            AddPrimaryKey("dbo.Enrollment", new[] { "CourseId", "StudentId", "Date" });
        }
    }
}
