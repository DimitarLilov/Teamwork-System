namespace TeamworkSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "Name");
        }
    }
}
