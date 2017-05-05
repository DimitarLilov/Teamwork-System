using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkSystem.Models.BindingModels.Teams;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;
using TeamworkSystem.Models.ViewModels.Teams;
using TeamworkSystem.Models.ViewModels.Teams.Board;
using TeamworkSystem.Services;

namespace TeamworkSystem.Tests.Services
{
    [TestClass]
    public class TestTeamsService : BaseTest
    {
        private TeamsService teamsService;

        [TestInitialize]
        public void Init()
        {
            this.teamsService = new TeamsService(this.Data);
        }

        [TestMethod]
        public void Test_TeamViewModelById_Should_Return_TeamViewModel()
        {
            // Arrange
            TeamViewModel vm = new TeamViewModel { Id = 1 };

            Team team = this.Data.Teams.GetById(1);

            IEnumerable<Project> projects = team.Projects.Where(p => p.IsPublic).Take(4);
            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

            IEnumerable<Course> courses = team.Projects.Select(p => p.Course).Take(4).Distinct();
            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);


            // Act
            TeamViewModel serviceGetResult = this.teamsService.GetTeam(1);

            // Assert
            Assert.AreEqual(vm.Projects.Count(), serviceGetResult.Projects.Count());
        }
        [TestMethod]
        public void Test_GetMembersName_Should_Return_MembersName()
        {
            // Arrange
            var vm = this.Data.Teams.GetById(1).Members.Select(m => m.IdentityUser.UserName);
            // Act
            IEnumerable<string> serviceGetResult = this.teamsService.GetMembersName(1);

            // Assert
            Assert.AreEqual(vm.Count(), serviceGetResult.Count());
        }
        [TestMethod]
        public void Test_AllTeamsProjects_Should_Return_AllTeamsProjectsViewModel()
        {
            // Arrange
            AllTeamsProjectsViewModel vm = new AllTeamsProjectsViewModel { Id = 1 };

            IEnumerable<Project> project = this.Data.Teams.GetById(1).Projects.Where(p => p.IsPublic);

            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(project);

            // Act
            AllTeamsProjectsViewModel serviceGetResult = this.teamsService.GetAllProjects(1);

            // Assert
            Assert.AreEqual(vm.Projects.Count(), serviceGetResult.Projects.Count());
        }

        [TestMethod]
        public void Test_TeamsInfo_Should_Return_TeamInfoViewModel()
        {
            // Arrange
            Team team = this.Data.Teams.GetById(1);
            TeamInfoViewModel vm = Mapper.Map<Team, TeamInfoViewModel>(team);
            // Act
            TeamInfoViewModel serviceGetResult = this.teamsService.GetTeamInfo(1);

            // Assert
            Assert.AreEqual(vm.Name, serviceGetResult.Name);
        }

        [TestMethod]
        public void Test_AllTeamsCourses_Should_Return_AllTeamsCoursesViewModel()
        {
            // Arrange
            AllTeamsCoursesViewModel vm = new AllTeamsCoursesViewModel { Id = 1 };


            IEnumerable<Course> courses = Data.Teams.GetById(1).Projects.Select(p => p.Course).Distinct();

            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);
            // Act
            AllTeamsCoursesViewModel serviceGetResult = this.teamsService.GetAllTaemsCourses(1);

            // Assert
            Assert.AreEqual(vm.Courses.Count(), serviceGetResult.Courses.Count());
        }

        [TestMethod]
        public void Test_GetTeamTasks_Should_Return_TeamTasksViewModel()
        {
            // Arrange
            TeamTasksViewModel vm = new TeamTasksViewModel { TeamId = 1 };
            Team team = this.Data.Teams.GetById(1);

            IEnumerable<TeamTask> tasks = team.Tasks.Where(t => t.IsComplet == false);

            vm.Tasks = Mapper.Map<IEnumerable<TeamTask>, IEnumerable<TaskViewModel>>(tasks);
            // Act
            TeamTasksViewModel serviceGetResult = this.teamsService.GetTeamTasks(1);

            // Assert
            Assert.AreEqual(vm.Tasks.Count(), serviceGetResult.Tasks.Count());
        }

        [TestMethod]
        public void Test_CreateTeam_Should_Create_Team()
        {
            // Arrange
            CreateTeamBindingModel bm = new CreateTeamBindingModel()
            {
                Name = "Ceca",
                Description = "Golqm team"
            };
            // Act
            var id = this.teamsService.CreateTeam(bm, "Mici");

            // Assert
            Assert.AreEqual(bm.Name, this.Data.Teams.GetById(id).Name);
        }
        [TestMethod]
        public void Test_AddMemberInTeam_Should_Create_TeamMember()
        {
            // Arrange
            AddMemberBindingModel bm = new AddMemberBindingModel()
            {
                Username = "Duci"
            };
            // Act
             this.teamsService.AddMember(1,bm);

            // Assert
            Assert.AreEqual(bm.Username, this.Data.Teams.GetById(1).Members.Select(t => t.IdentityUser.UserName));
        }
        [TestMethod]
        public void Test_TeamCreateProject_Should_Create_Project()
        {
            // Arrange
            AddProjectBindingModel bm = new AddProjectBindingModel()
            {
                Name = "Belot",
                CourseId = 1,
                Description = "nqma",
                IsPublic = true,
                LiveDemo = "nqma",
                Repository = "pak nqma"
            };
            // Act
             this.teamsService.CreateProject(1,bm);

            // Assert
            Assert.AreEqual(bm.Name, this.Data.Teams.GetById(1).Projects.Select(p => p.Name));
        }
        [TestMethod]
        public void Test_GetBoardInfo_Should_Return_BoardInfoViewModel()
        {
            // Arrange
           var vm = Mapper.Map<Team, BoardInfoViewModel>(this.Data.Teams.GetById(1));
            // Act
            BoardInfoViewModel serviceGetResult = teamsService.GetBoardInfo(1);

            // Assert
            Assert.AreEqual(vm.Name, serviceGetResult.Name);
        }
        [TestMethod]
        public void Test_GetAllMembers_Should_Return_MembersViewModel()
        {
            // Arrange
            MembersViewModel vm = new MembersViewModel { TeamId = 1 };
            IEnumerable<Student> members = this.Data.Teams.GetById(1).Members;
            vm.Members = Mapper.Map<IEnumerable<Student>, IEnumerable<BoardMemberViewModel>>(members);
            // Act
            MembersViewModel serviceGetResult = teamsService.GetAllMembers(1);

            // Assert
            Assert.AreEqual(vm.Members.Count(), serviceGetResult.Members.Count());
        }
        [TestMethod]
        public void Test_EditTeam_Should_Edit_Teaml()
        {
            // Arrange
            EditTeamBindingModel bm = new EditTeamBindingModel()
            {
                Description = "nqma nqma "
            };
            // Act
            this.teamsService.EditTeam(bm,1);

            // Assert
            Assert.AreEqual(bm.Description, this.Data.Teams.GetById(1).Description);
        }
    }
}
