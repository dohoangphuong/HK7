namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Procedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Trainee_Insert",
                p => new
                    {
                        TraineeId = p.String(maxLength: 10, unicode: false),
                        FirstName = p.String(maxLength: 25),
                        LastName = p.String(maxLength: 25),
                        Account = p.String(maxLength: 20, unicode: false),
                        Password = p.String(maxLength: 32),
                    },
                body:
                    @"INSERT [dbo].[Trainee]([TraineeId], [FirstName], [LastName], [Account], [Password])
                      VALUES (@TraineeId, @FirstName, @LastName, @Account, @Password)
                      
                      SELECT t0.[TraineeNo]
                      FROM [dbo].[Trainee] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TraineeId] = @TraineeId"
            );
            
            CreateStoredProcedure(
                "dbo.Trainee_Update",
                p => new
                    {
                        TraineeId = p.String(maxLength: 10, unicode: false),
                        TraineeNo = p.Int(),
                        FirstName = p.String(maxLength: 25),
                        LastName = p.String(maxLength: 25),
                        Account = p.String(maxLength: 20, unicode: false),
                        Password = p.String(maxLength: 32),
                    },
                body:
                    @"UPDATE [dbo].[Trainee]
                      SET [FirstName] = @FirstName, [LastName] = @LastName, [Account] = @Account, [Password] = @Password
                      WHERE ([TraineeId] = @TraineeId)"
            );
            
            CreateStoredProcedure(
                "dbo.Trainee_Delete",
                p => new
                    {
                        TraineeId = p.String(maxLength: 10, unicode: false),
                    },
                body:
                    @"DELETE [dbo].[Trainee]
                      WHERE ([TraineeId] = @TraineeId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Trainee_Delete");
            DropStoredProcedure("dbo.Trainee_Update");
            DropStoredProcedure("dbo.Trainee_Insert");
        }
    }
}
