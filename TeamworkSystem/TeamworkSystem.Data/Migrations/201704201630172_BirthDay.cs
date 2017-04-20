namespace TeamworkSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class BirthDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "BirthBay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "BirthBay", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "BirthDay");
        }
    }
}
