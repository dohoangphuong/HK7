namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_attribute_email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainee", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterStoredProcedure(
                "dbo.Trainee_Insert",
                p => new
                    {
                        TraineeId = p.String(maxLength: 10, unicode: false),
                        FirstName = p.String(maxLength: 25),
                        LastName = p.String(maxLength: 25),
                        Account = p.String(maxLength: 20, unicode: false),
                        Password = p.String(maxLength: 32),
                        Email = p.String(maxLength: 30),
                    },
                body:
                    @"INSERT [dbo].[Trainee]([TraineeId], [FirstName], [LastName], [Account], [Password], [Email])
                      VALUES (@TraineeId, @FirstName, @LastName, @Account, @Password, @Email)
                      
                      SELECT t0.[TraineeNo]
                      FROM [dbo].[Trainee] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TraineeId] = @TraineeId"
            );
            
            AlterStoredProcedure(
                "dbo.Trainee_Update",
                p => new
                    {
                        TraineeId = p.String(maxLength: 10, unicode: false),
                        TraineeNo = p.Int(),
                        FirstName = p.String(maxLength: 25),
                        LastName = p.String(maxLength: 25),
                        Account = p.String(maxLength: 20, unicode: false),
                        Password = p.String(maxLength: 32),
                        Email = p.String(maxLength: 30),
                    },
                body:
                    @"UPDATE [dbo].[Trainee]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Account] = @Account, [Password] = @Password, [Email] = @Email
                      WHERE ([TraineeId] = @TraineeId)"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainee", "Email");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
