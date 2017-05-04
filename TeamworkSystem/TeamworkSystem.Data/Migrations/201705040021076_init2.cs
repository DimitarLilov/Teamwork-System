namespace TeamworkSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CourseAssistents", newName: "AssistentCourses");
            RenameTable(name: "dbo.AlbumPhotoes", newName: "PhotoAlbums");
            DropPrimaryKey("dbo.AssistentCourses");
            DropPrimaryKey("dbo.PhotoAlbums");
            AddPrimaryKey("dbo.AssistentCourses", new[] { "Assistent_Id", "Course_Id" });
            AddPrimaryKey("dbo.PhotoAlbums", new[] { "Photo_Id", "Album_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PhotoAlbums");
            DropPrimaryKey("dbo.AssistentCourses");
            AddPrimaryKey("dbo.PhotoAlbums", new[] { "Album_Id", "Photo_Id" });
            AddPrimaryKey("dbo.AssistentCourses", new[] { "Course_Id", "Assistent_Id" });
            RenameTable(name: "dbo.PhotoAlbums", newName: "AlbumPhotoes");
            RenameTable(name: "dbo.AssistentCourses", newName: "CourseAssistents");
        }
    }
}
