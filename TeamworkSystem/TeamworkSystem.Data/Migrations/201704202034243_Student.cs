namespace TeamworkSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Students", name: "User_Id", newName: "IdenityUserId");
            RenameIndex(table: "dbo.Students", name: "IX_User_Id", newName: "IX_IdenityUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Students", name: "IX_IdenityUserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Students", name: "IdenityUserId", newName: "User_Id");
        }
    }
}
