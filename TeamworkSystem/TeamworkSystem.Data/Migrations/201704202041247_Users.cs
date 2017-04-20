namespace TeamworkSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Trainers", name: "User_Id", newName: "IdenityUserId");
            RenameColumn(table: "dbo.Assistents", name: "User_Id", newName: "IdenityUserId");
            RenameIndex(table: "dbo.Assistents", name: "IX_User_Id", newName: "IX_IdenityUserId");
            RenameIndex(table: "dbo.Trainers", name: "IX_User_Id", newName: "IX_IdenityUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Trainers", name: "IX_IdenityUserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Assistents", name: "IX_IdenityUserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Assistents", name: "IdenityUserId", newName: "User_Id");
            RenameColumn(table: "dbo.Trainers", name: "IdenityUserId", newName: "User_Id");
        }
    }
}
