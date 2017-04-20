namespace TeamworkSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assistents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
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
                        Trainer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainers", t => t.Trainer_Id)
                .Index(t => t.Trainer_Id);
            
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
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlPthoto = c.String(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
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
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                        TeamTask_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.TeamTasks", t => t.TeamTask_Id)
                .Index(t => t.User_Id)
                .Index(t => t.TeamTask_Id);
            
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
                "dbo.TeamTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsComplet = c.Boolean(nullable: false),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.ProjectCriterias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Point = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                "dbo.StudentTeams",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Team_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Team_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Team_Id);
            
            AddColumn("dbo.Projects", "Description", c => c.String());
            AddColumn("dbo.Projects", "Repository", c => c.String());
            AddColumn("dbo.Projects", "LiveDemo", c => c.String());
            AddColumn("dbo.Projects", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "IsPublic", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "Vote", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Grade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Projects", "Course_Id", c => c.Int());
            AddColumn("dbo.Projects", "ProjectPicture_Id", c => c.Int());
            AddColumn("dbo.Projects", "Team_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "WebSite", c => c.String());
            AddColumn("dbo.AspNetUsers", "AbautMe", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "Town", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthBay", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "SoftUniProfile", c => c.String());
            AddColumn("dbo.AspNetUsers", "Facebook", c => c.String());
            AddColumn("dbo.AspNetUsers", "Twitter", c => c.String());
            AddColumn("dbo.AspNetUsers", "GooglePlus", c => c.String());
            AddColumn("dbo.AspNetUsers", "LinkedIn", c => c.String());
            AddColumn("dbo.AspNetUsers", "GitHub", c => c.String());
            AddColumn("dbo.AspNetUsers", "StackOverflow", c => c.String());
            AddColumn("dbo.AspNetUsers", "Instagram", c => c.String());
            AddColumn("dbo.AspNetUsers", "Skype", c => c.String());
            AddColumn("dbo.AspNetUsers", "ProfilePhoto_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Course_Id");
            CreateIndex("dbo.Projects", "ProjectPicture_Id");
            CreateIndex("dbo.Projects", "Team_Id");
            CreateIndex("dbo.AspNetUsers", "ProfilePhoto_Id");
            AddForeignKey("dbo.Projects", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Projects", "ProjectPicture_Id", "dbo.Photos", "Id");
            AddForeignKey("dbo.AspNetUsers", "ProfilePhoto_Id", "dbo.Photos", "Id");
            AddForeignKey("dbo.Projects", "Team_Id", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assistents", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectCriterias", "Assistent_Id", "dbo.Assistents");
            DropForeignKey("dbo.Trainers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.ProjectCriterias", "Trainer_Id", "dbo.Trainers");
            DropForeignKey("dbo.ProjectCriterias", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.ProjectCriterias", "Criteria_Id", "dbo.Criteria");
            DropForeignKey("dbo.TeamTasks", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Students", "TeamTask_Id", "dbo.TeamTasks");
            DropForeignKey("dbo.Projects", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Messages", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Messages", "Sender_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skills", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ProfilePhoto_Id", "dbo.Photos");
            DropForeignKey("dbo.StudentTeams", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.StudentTeams", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Projects", "ProjectPicture_Id", "dbo.Photos");
            DropForeignKey("dbo.Photos", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Criteria", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.CourseAssistents", "Assistent_Id", "dbo.Assistents");
            DropForeignKey("dbo.CourseAssistents", "Course_Id", "dbo.Courses");
            DropIndex("dbo.StudentTeams", new[] { "Team_Id" });
            DropIndex("dbo.StudentTeams", new[] { "Student_Id" });
            DropIndex("dbo.CourseAssistents", new[] { "Assistent_Id" });
            DropIndex("dbo.CourseAssistents", new[] { "Course_Id" });
            DropIndex("dbo.ProjectCriterias", new[] { "Assistent_Id" });
            DropIndex("dbo.ProjectCriterias", new[] { "Trainer_Id" });
            DropIndex("dbo.ProjectCriterias", new[] { "Project_Id" });
            DropIndex("dbo.ProjectCriterias", new[] { "Criteria_Id" });
            DropIndex("dbo.Trainers", new[] { "User_Id" });
            DropIndex("dbo.TeamTasks", new[] { "Team_Id" });
            DropIndex("dbo.Messages", new[] { "Team_Id" });
            DropIndex("dbo.Messages", new[] { "Sender_Id" });
            DropIndex("dbo.Skills", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "ProfilePhoto_Id" });
            DropIndex("dbo.Students", new[] { "TeamTask_Id" });
            DropIndex("dbo.Students", new[] { "User_Id" });
            DropIndex("dbo.Photos", new[] { "Project_Id" });
            DropIndex("dbo.Projects", new[] { "Team_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectPicture_Id" });
            DropIndex("dbo.Projects", new[] { "Course_Id" });
            DropIndex("dbo.Criteria", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Trainer_Id" });
            DropIndex("dbo.Assistents", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "ProfilePhoto_Id");
            DropColumn("dbo.AspNetUsers", "Skype");
            DropColumn("dbo.AspNetUsers", "Instagram");
            DropColumn("dbo.AspNetUsers", "StackOverflow");
            DropColumn("dbo.AspNetUsers", "GitHub");
            DropColumn("dbo.AspNetUsers", "LinkedIn");
            DropColumn("dbo.AspNetUsers", "GooglePlus");
            DropColumn("dbo.AspNetUsers", "Twitter");
            DropColumn("dbo.AspNetUsers", "Facebook");
            DropColumn("dbo.AspNetUsers", "SoftUniProfile");
            DropColumn("dbo.AspNetUsers", "BirthBay");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Town");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "AbautMe");
            DropColumn("dbo.AspNetUsers", "WebSite");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Projects", "Team_Id");
            DropColumn("dbo.Projects", "ProjectPicture_Id");
            DropColumn("dbo.Projects", "Course_Id");
            DropColumn("dbo.Projects", "Grade");
            DropColumn("dbo.Projects", "Vote");
            DropColumn("dbo.Projects", "IsPublic");
            DropColumn("dbo.Projects", "IsActive");
            DropColumn("dbo.Projects", "LiveDemo");
            DropColumn("dbo.Projects", "Repository");
            DropColumn("dbo.Projects", "Description");
            DropTable("dbo.StudentTeams");
            DropTable("dbo.CourseAssistents");
            DropTable("dbo.ProjectCriterias");
            DropTable("dbo.Trainers");
            DropTable("dbo.TeamTasks");
            DropTable("dbo.Messages");
            DropTable("dbo.Skills");
            DropTable("dbo.Students");
            DropTable("dbo.Teams");
            DropTable("dbo.Photos");
            DropTable("dbo.Criteria");
            DropTable("dbo.Courses");
            DropTable("dbo.Assistents");
        }
    }
}
