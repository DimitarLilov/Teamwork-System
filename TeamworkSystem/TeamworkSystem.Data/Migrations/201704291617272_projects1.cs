namespace TeamworkSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projects1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProjectPoints", name: "Assistent_Id", newName: "PointAssistent_Id");
            RenameColumn(table: "dbo.ProjectPoints", name: "Trainer_Id", newName: "PointTrainer_Id");
            RenameIndex(table: "dbo.ProjectPoints", name: "IX_Assistent_Id", newName: "IX_PointAssistent_Id");
            RenameIndex(table: "dbo.ProjectPoints", name: "IX_Trainer_Id", newName: "IX_PointTrainer_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProjectPoints", name: "IX_PointTrainer_Id", newName: "IX_Trainer_Id");
            RenameIndex(table: "dbo.ProjectPoints", name: "IX_PointAssistent_Id", newName: "IX_Assistent_Id");
            RenameColumn(table: "dbo.ProjectPoints", name: "PointTrainer_Id", newName: "Trainer_Id");
            RenameColumn(table: "dbo.ProjectPoints", name: "PointAssistent_Id", newName: "Assistent_Id");
        }
    }
}
