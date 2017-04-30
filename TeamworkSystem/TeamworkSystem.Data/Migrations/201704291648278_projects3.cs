namespace TeamworkSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projects3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectPoints", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectPoints", new[] { "Project_Id" });
            RenameColumn(table: "dbo.ProjectPoints", name: "Project_Id", newName: "ProjectId");
            AlterColumn("dbo.ProjectPoints", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectPoints", "ProjectId");
            AddForeignKey("dbo.ProjectPoints", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectPoints", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectPoints", new[] { "ProjectId" });
            AlterColumn("dbo.ProjectPoints", "ProjectId", c => c.Int());
            RenameColumn(table: "dbo.ProjectPoints", name: "ProjectId", newName: "Project_Id");
            CreateIndex("dbo.ProjectPoints", "Project_Id");
            AddForeignKey("dbo.ProjectPoints", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
