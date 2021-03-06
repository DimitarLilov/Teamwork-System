namespace TeamworkSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assistents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdenityUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdenityUserId)
                .Index(t => t.IdenityUserId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MaxGrade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CoursePhoto_Id = c.Int(),
                        Trainer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.CoursePhoto_Id)
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id)
                .Index(t => t.CoursePhoto_Id)
                .Index(t => t.Trainer_Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlPthoto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Repository = c.String(),
                        LiveDemo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsPublic = c.Boolean(nullable: false),
                        Vote = c.Int(nullable: false),
                        Grade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Team_Id = c.Int(),
                        Course_Id = c.Int(),
                        Photos_Id = c.Int(),
                        ProjectPicture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Albums", t => t.Photos_Id)
                .ForeignKey("dbo.Photos", t => t.ProjectPicture_Id)
                .Index(t => t.Team_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Photos_Id)
                .Index(t => t.ProjectPicture_Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Author_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdenityUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdenityUserId)
                .Index(t => t.IdenityUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        WebSite = c.String(),
                        AboutMe = c.String(),
                        Country = c.String(),
                        Town = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDay = c.DateTime(),
                        SoftUniProfile = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        GooglePlus = c.String(),
                        LinkedIn = c.String(),
                        GitHub = c.String(),
                        StackOverflow = c.String(),
                        Instagram = c.String(),
                        Skype = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        ProfilePhoto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.ProfilePhoto_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.ProfilePhoto_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SkillName = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.TeamTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsComplet = c.Boolean(nullable: false),
                        Author_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Author_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        Sender_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Sender_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.ProjectPoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Criteria_Id = c.Int(),
                        Project_Id = c.Int(),
                        Trainer_Id = c.Int(),
                        Assistent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Criteria", t => t.Criteria_Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id)
                .ForeignKey("dbo.Assistents", t => t.Assistent_Id)
                .Index(t => t.Criteria_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.Trainer_Id)
                .Index(t => t.Assistent_Id);
            
            CreateTable(
                "dbo.Criteria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdenityUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdenityUserId)
                .Index(t => t.IdenityUserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CourseAssistents",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Assistent_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Assistent_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Assistents", t => t.Assistent_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Assistent_Id);
            
            CreateTable(
                "dbo.AlbumPhotoes",
                c => new
                    {
                        Album_Id = c.Int(nullable: false),
                        Photo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Album_Id, t.Photo_Id })
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.Photo_Id, cascadeDelete: true)
                .Index(t => t.Album_Id)
                .Index(t => t.Photo_Id);
            
            CreateTable(
                "dbo.StudentTask",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.TaskId })
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.TeamTasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.TeamStudents",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.Student_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProjectPoints", "Assistent_Id", "dbo.Assistents");
            DropForeignKey("dbo.Assistents", "IdenityUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectPoints", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.Courses", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.Trainers", "IdenityUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Criteria", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Projects", "ProjectPicture_Id", "dbo.Photos");
            DropForeignKey("dbo.ProjectPoints", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectPoints", "Criteria_Id", "dbo.Criteria");
            DropForeignKey("dbo.Projects", "Photos_Id", "dbo.Albums");
            DropForeignKey("dbo.Projects", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Comments", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Comments", "Author_Id", "dbo.Students");
            DropForeignKey("dbo.TeamTasks", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Projects", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Messages", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Students");
            DropForeignKey("dbo.TeamStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.TeamStudents", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.StudentTask", "TaskId", "dbo.TeamTasks");
            DropForeignKey("dbo.StudentTask", "StudentId", "dbo.Students");
            DropForeignKey("dbo.TeamTasks", "Author_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "IdenityUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skills", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ProfilePhoto_Id", "dbo.Photos");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CoursePhoto_Id", "dbo.Photos");
            DropForeignKey("dbo.AlbumPhotoes", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.AlbumPhotoes", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.CourseAssistents", "Assistent_Id", "dbo.Assistents");
            DropForeignKey("dbo.CourseAssistents", "Course_Id", "dbo.Courses");
            DropIndex("dbo.TeamStudents", new[] { "Student_Id" });
            DropIndex("dbo.TeamStudents", new[] { "Team_Id" });
            DropIndex("dbo.StudentTask", new[] { "TaskId" });
            DropIndex("dbo.StudentTask", new[] { "StudentId" });
            DropIndex("dbo.AlbumPhotoes", new[] { "Photo_Id" });
            DropIndex("dbo.AlbumPhotoes", new[] { "Album_Id" });
            DropIndex("dbo.CourseAssistents", new[] { "Assistent_Id" });
            DropIndex("dbo.CourseAssistents", new[] { "Course_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Trainers", new[] { "IdenityUserId" });
            DropIndex("dbo.Criteria", new[] { "Course_Id" });
            DropIndex("dbo.ProjectPoints", new[] { "Assistent_Id" });
            DropIndex("dbo.ProjectPoints", new[] { "Trainer_Id" });
            DropIndex("dbo.ProjectPoints", new[] { "Project_Id" });
            DropIndex("dbo.ProjectPoints", new[] { "Criteria_Id" });
            DropIndex("dbo.Messages", new[] { "Team_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.TeamTasks", new[] { "Team_Id" });
            DropIndex("dbo.TeamTasks", new[] { "Author_Id" });
            DropIndex("dbo.Skills", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "ProfilePhoto_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Students", new[] { "IdenityUserId" });
            DropIndex("dbo.Comments", new[] { "Project_Id" });
            DropIndex("dbo.Comments", new[] { "Author_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectPicture_Id" });
            DropIndex("dbo.Projects", new[] { "Photos_Id" });
            DropIndex("dbo.Projects", new[] { "Course_Id" });
            DropIndex("dbo.Projects", new[] { "Team_Id" });
            DropIndex("dbo.Courses", new[] { "Trainer_Id" });
            DropIndex("dbo.Courses", new[] { "CoursePhoto_Id" });
            DropIndex("dbo.Assistents", new[] { "IdenityUserId" });
            DropTable("dbo.TeamStudents");
            DropTable("dbo.StudentTask");
            DropTable("dbo.AlbumPhotoes");
            DropTable("dbo.CourseAssistents");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Trainers");
            DropTable("dbo.Criteria");
            DropTable("dbo.ProjectPoints");
            DropTable("dbo.Messages");
            DropTable("dbo.Teams");
            DropTable("dbo.TeamTasks");
            DropTable("dbo.Skills");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Students");
            DropTable("dbo.Comments");
            DropTable("dbo.Projects");
            DropTable("dbo.Albums");
            DropTable("dbo.Photos");
            DropTable("dbo.Courses");
            DropTable("dbo.Assistents");
        }
    }
}
