namespace TeamworkSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class photo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teams", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.Teams", new[] { "Photo_Id" });
            DropColumn("dbo.Teams", "Photo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teams", "Photo_Id", c => c.Int());
            CreateIndex("dbo.Teams", "Photo_Id");
            AddForeignKey("dbo.Teams", "Photo_Id", "dbo.Photos", "Id");
        }
    }
}
