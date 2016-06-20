namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_Attribute_Rate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FeedbackDetail", "Rate", c => c.Byte(nullable: false));
            DropColumn("dbo.FeedbackType", "Rate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FeedbackType", "Rate", c => c.Byte(nullable: false));
            DropColumn("dbo.FeedbackDetail", "Rate");
        }
    }
}
