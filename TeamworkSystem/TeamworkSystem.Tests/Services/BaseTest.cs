namespace TeamworkSystem.Tests.Services
{
    using System;
    using System.Collections.Generic;

    using TeamworkSystem.Data.Moks;
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.EnitityModels.Users;

    public abstract class BaseTest
    {
        protected FakeTeamworkSystemContext DbContext;
        protected FakeTeamworkSystemData Data;

        protected BaseTest()
        {
            this.DbContext = new FakeTeamworkSystemContext();
            this.Data = new FakeTeamworkSystemData(this.DbContext);
            this.SeedData();
            MapperConfig.ConfigureAutomapper();
        }

        protected void SeedData()
        {
            // Seed students
            this.Data.Students.Insert(new Student()
            {
                Id = 1,
                IdentityUser = new ApplicationUser()
                {
                    UserName = "Mici",
                    FirstName = "Dimitar",
                    LastName = "Lilov",
                    BirthDate = new DateTime(1992, 04, 26),
                    Id = "asfq3rnbrkh2eh23rjh32"
                },
                IdenityUserId = "asfq3rnbrkh2eh23rjh32"
            });
            this.Data.Students.Insert(new Student()
            {
                Id = 2,
                IdentityUser = new ApplicationUser()
                {
                    UserName = "Joro",
                    FirstName = "Georgi",
                    LastName = "Todorov",
                    BirthDate = new DateTime(1999, 01, 01),
                    Id = "asfkh2eh23rjh32"
                },
                IdenityUserId = "asfkh2eh23rjh32",
            });
            this.Data.Students.Insert(new Student()
            {
                Id = 3,
                IdentityUser = new ApplicationUser()
                {
                    UserName = "Duci",
                    FirstName = "Niki",
                    LastName = "Dutskinov",
                    BirthDate = new DateTime(1995, 01, 01),
                    Id = "asdfassasascslkjda32423"
                },
                IdenityUserId = "asdfassasascslkjda32423",
            });

            // Seed Trainer
            this.Data.Trainers.Insert(new Trainer()
            {
                Id = 1,
                IdenityUserId = "asfq3rnbrkh2eh23rjh32",
            });

            // Seed criteria
            this.Data.Criteria.Insert(new Criteria()
            {
                Id = 1,
                Name = "UI"
            });
            this.Data.Criteria.Insert(new Criteria()
            {
                Id = 2,
                Name = "test"
            });

            // Seed courses
            this.Data.Courses.Insert(new Course()
            {
                Id = 1,
                Name = "C#",
                Description =
                    "Qk ezik",
                MaxGrade = 100,
                Trainer = this.Data.Trainers.GetById(1),
                EndDate = new DateTime(2017, 01, 01),
                StartDate = new DateTime(2217, 01, 01)
            });

            var members = new List<Student>();
            members.Add(this.Data.Students.GetById(1));
            members.Add(this.Data.Students.GetById(2));

            // Seed team 
            this.Data.Teams.Insert(new Team()
            {
                Name = "Bachkatorite",
                Description = "Rabotnici",
                Id = 1,
                Members = members,
                                       });

            this.Data.Projects.Insert(new Project()
            {
                Course = this.Data.Courses.GetById(1),
                Name = "Poker",
                Team = this.Data.Teams.GetById(1),
                Id = 1,
                PublishDate = new DateTime(1254, 12, 14)
            });
        }
    }
}
