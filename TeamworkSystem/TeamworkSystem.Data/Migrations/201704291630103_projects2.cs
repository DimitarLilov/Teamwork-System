namespace TeamworkSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projects2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectPoints", "Criteria_Id", "dbo.Criteria");
            DropIndex("dbo.ProjectPoints", new[] { "Criteria_Id" });
            RenameColumn(table: "dbo.ProjectPoints", name: "Criteria_Id", newName: "CriteriaId");
            AlterColumn("dbo.ProjectPoints", "CriteriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectPoints", "CriteriaId");
            AddForeignKey("dbo.ProjectPoints", "CriteriaId", "dbo.Criteria", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectPoints", "CriteriaId", "dbo.Criteria");
            DropIndex("dbo.ProjectPoints", new[] { "CriteriaId" });
            AlterColumn("dbo.ProjectPoints", "CriteriaId", c => c.Int());
            RenameColumn(table: "dbo.ProjectPoints", name: "CriteriaId", newName: "Criteria_Id");
            CreateIndex("dbo.ProjectPoints", "Criteria_Id");
            AddForeignKey("dbo.ProjectPoints", "Criteria_Id", "dbo.Criteria", "Id");
        }
    }
}
