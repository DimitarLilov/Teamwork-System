using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.BindingModels.Teams;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;
using TeamworkSystem.Models.ViewModels.Teams;

namespace TeamworkSystem.Services
{
    public class TeamsService : Service
    {
        public TeamsService(ITeamworkSystemData data) : base(data)
        {

        }

        public TeamViewModel GetTeam(int id)
        {
            TeamViewModel vm = new TeamViewModel();

            Team team = this.data.Teams.GetById(id);
            TeamInfoViewModel teamInfo = Mapper.Map<Team, TeamInfoViewModel>(team);
            vm.Team = teamInfo;

            IEnumerable<Project> projects = team.Projects.Take(4);
            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

            IEnumerable<Course> courses = team.Projects.Select(p => p.Course).Take(4).Distinct();
            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return vm;
        }


        public IEnumerable<string> GetMembersName(int id)
        {
            return this.data.Teams.FindByPredicate(t => t.Id == id).Members.Select(m => m.IdentityUser.UserName);
        }

        public AllTeamsProjectsViewModel GetAllProjects(int id)
        {
            AllTeamsProjectsViewModel viewModel = new AllTeamsProjectsViewModel();

            viewModel.Team = GetTeamInfo(id);

            IEnumerable<Project> project = this.data.Teams.FindByPredicate(t => t.Id == id).Projects;

            viewModel.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(project);

            return viewModel;
        }

        public TeamInfoViewModel GetTeamInfo(int id)
        {
            Team team = this.data.Teams.GetById(id);
            TeamInfoViewModel teamInfo = Mapper.Map<Team, TeamInfoViewModel>(team);
            return teamInfo;
        }

        public AllTeamsCoursesViewModel GetAllCourses(int id)
        {
            AllTeamsCoursesViewModel viewModel = new AllTeamsCoursesViewModel();

            Team team = this.data.Teams.GetById(id);
            TeamInfoViewModel teamInfo = Mapper.Map<Team, TeamInfoViewModel>(team);
            viewModel.Team = teamInfo;

            IEnumerable<Course> courses = this.data.Teams.FindByPredicate(t => t.Id == id).Projects.Select(p => p.Course).Distinct();

            viewModel.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return viewModel;
        }

        public DashboardInfoViewModel GetTeamDashboard(int id)
        {
            Team team = this.data.Teams.GetById(id);
            DashboardInfoViewModel vm = Mapper.Map<Team, DashboardInfoViewModel>(team);

            return vm;
        }

        public TeamTasksViewModel GetTeamTasks(int id)
        {
            TeamTasksViewModel vm = new TeamTasksViewModel();
            Team team = this.data.Teams.GetById(id);

            vm.TeamInfo = Mapper.Map<Team, DashboardInfoViewModel>(team);

            IEnumerable<TeamTask> tasks = team.Tasks.Where(t => t.IsComplet == false);

            vm.Tasks = Mapper.Map<IEnumerable<TeamTask>, IEnumerable<TaskViewModel>>(tasks);

            return vm;
        }

        public IEnumerable<string> GettUsernames()
        {
            return this.data.User.GetAll().Select(u => u.UserName.ToLower());
        }

        public int CreateTeam(CreateTeamBindingModel binding, string username)
        {
            Student student = this.data.Students.FindByPredicate(s => s.IdentityUser.UserName == username);
            Team team = Mapper.Map<CreateTeamBindingModel, Team>(binding);
            team.Members.Add(student);

            this.data.Teams.Insert(team);
            this.data.SaveChanges();

            return team.Id;
        }


        public void AddMember(int id, AddMemberBindingModel binding)
        {
            Student member = this.data.Students.FindByPredicate(s => s.IdentityUser.UserName == binding.Username);
            this.data.Teams.FindByPredicate(t => t.Id == id).Members.Add(member);
            this.data.SaveChanges();
        }

        public bool ContainsUser(AddMemberBindingModel binding)
        {
            if (this.data.User.FindByPredicate(u => u.UserName == binding.Username) != null)
            {
                return true;
            }
            return false;
        }

        public AddTaskViewModel GetTeamInfoForTask(int id)
        {
            AddTaskViewModel vm = new AddTaskViewModel();

            vm.Team = this.GetTeamInfo(id);
            var members = this.data.Teams.FindByPredicate(t => t.Id == id).Members;
            vm.Members = 
                Mapper.Map<IEnumerable<Student>, IEnumerable<SelectMemberViewModel>>(members);

            return vm;
        }

        public void AddTask(int id, AddTaskBindingModel binding, string username)
        {

            TeamTask task = new TeamTask()
            {
                Content = binding.Content,
                EndDate = binding.EndDate,
                StartDate = binding.StartDate
            };
            task.Author = this.data.Students.FindByPredicate(s => s.IdentityUser.UserName == username);
            foreach (var user in binding.Username)
            {
                var member = this.data.Students.FindByPredicate(s => s.IdentityUser.UserName == user);
                task.Members.Add(member); 
            }
            this.data.TeamTasks.Insert(task);
            this.data.Teams.FindByPredicate(t => t.Id == id).Tasks.Add(task);
            this.data.SaveChanges();
        }
    }
}
