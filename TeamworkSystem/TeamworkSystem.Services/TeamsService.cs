using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.BindingModels.Teams;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;
using TeamworkSystem.Models.ViewModels.Teams;
using TeamworkSystem.Models.ViewModels.Teams.Board;
using TeamworkSystem.Services.Contracts;
using TeamworkSystem.Utillities.Constants;

namespace TeamworkSystem.Services
{
   

    public class TeamsService : Service, ITeamsService
    {
        public TeamsService(ITeamworkSystemData data) : base(data)
        {

        }

        public TeamViewModel GetTeam(int id)
        {
            TeamViewModel vm = new TeamViewModel { Id = id };

            Team team = this.data.Teams.GetById(id);

            IEnumerable<Project> projects = team.Projects.Where(p => p.IsPublic).Take(4);
            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

            IEnumerable<Course> courses = team.Projects.Select(p => p.Course).Take(4).Distinct();
            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return vm;
        }


        public IEnumerable<string> GetMembersName(int id)
        {
            return this.data.Teams.GetById(id).Members.Select(m => m.IdentityUser.UserName);
        }

        public AllTeamsProjectsViewModel GetAllProjects(int id)
        {
            AllTeamsProjectsViewModel viewModel = new AllTeamsProjectsViewModel { Id = id };

            IEnumerable<Project> project = this.data.Teams.GetById(id).Projects.Where(p => p.IsPublic);

            viewModel.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(project);

            return viewModel;
        }

        public TeamInfoViewModel GetTeamInfo(int id)
        {
            Team team = this.data.Teams.GetById(id);
            TeamInfoViewModel teamInfo = Mapper.Map<Team, TeamInfoViewModel>(team);
            return teamInfo;
        }

        public AllTeamsCoursesViewModel GetAllTaemsCourses(int id)
        {
            AllTeamsCoursesViewModel viewModel = new AllTeamsCoursesViewModel { Id = id };


            IEnumerable<Course> courses = data.Teams.GetById(id).Projects.Select(p => p.Course).Distinct();

            viewModel.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return viewModel;
        }

        public BoardViewModel GetTeamBoard(int id, string username)
        {
            Team team = this.data.Teams.GetById(id);
            BoardViewModel vm = new BoardViewModel { TeamId = id };

            var tasks = team.Tasks.Where(t => t.IsComplet == true);

            var myTasks =
                this.data.Students.FindByPredicate(s => s.IdentityUser.UserName == username)
                    .Teams.First(t => t.Id == id).Tasks.Where(t => t.IsComplet == false);

            vm.ComplateTasks = Mapper.Map<IEnumerable<TeamTask>, IEnumerable<TaskViewModel>>(tasks);
            vm.MyTasks = Mapper.Map<IEnumerable<TeamTask>, IEnumerable<MyTaskViewModel>>(myTasks);
            return vm;
        }

        public TeamTasksViewModel GetTeamTasks(int id)
        {
            TeamTasksViewModel vm = new TeamTasksViewModel {TeamId = id};
            Team team = this.data.Teams.GetById(id);

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
            this.data.Teams.GetById(id).Members.Add(member);
            this.data.SaveChanges();
        }

        public bool ContainsUser(AddMemberBindingModel binding)
        {
            return this.data.User.FindByPredicate(u => u.UserName == binding.Username) != null;
        }

        public AddTaskViewModel GetTeamInfoForTask(int id)
        {
            AddTaskViewModel vm = new AddTaskViewModel {TeamId = id};

            var members = this.data.Teams.GetById(id).Members;
            vm.Members =
                Mapper.Map<IEnumerable<Student>, IEnumerable<SelectMemberViewModel>>(members);

            return vm;
        }

        public void AddTask(int id, AddTaskBindingModel binding, string username)
        {

            TeamTask task = new TeamTask
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
            this.data.Teams.GetById(id).Tasks.Add(task);
            this.data.SaveChanges();
        }

        public void CompleteTasks(CompleteTasksBindingModel binding)
        {
            foreach (var taskId in binding.TasksId)
            {
                TeamTask task = this.data.TeamTasks.GetById(taskId);
                task.EndDate = DateTime.Now;
                task.IsComplet = true;
            }
            this.data.SaveChanges();
        }

        public BoardProjectsViewModel GetTeamBoardProjects(int id)
        {
            Team team = this.data.Teams.GetById(id);

            BoardProjectsViewModel vm = new BoardProjectsViewModel
            {
                Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(team.Projects),
                TeamId = id
            };
            return vm;
        }

        public IEnumerable<ProjectCoursesViewModel> GetAllCourses()
        {
            IEnumerable<Course> courses = this.data.Courses.GetAll();

            return Mapper.Map<IEnumerable<Course>, IEnumerable<ProjectCoursesViewModel>>(courses);
        }

        public void CreateProject(int id, AddProjectBindingModel binding)
        {
            Team team = this.data.Teams.GetById(id);
            Course course = this.data.Courses.GetById(binding.CourseId);
            Photo pic = this.data.Photos.FindByPredicate(p => p.UrlPthoto == PathConstants.UnknownProject);

            Project project = Mapper.Map<AddProjectBindingModel, Project>(binding);
            project.Team = team;
            project.Course = course;
            project.ProjectPicture = pic;
            project.PublishDate = DateTime.Now;

            team.Projects.Add(project);
            course.Projects.Add(project);

            this.data.Projects.Insert(project);
            this.data.SaveChanges();
        }

        public bool ContainsTeam(int id)
        {
            return this.data.Teams.FindByPredicate(t => t.Id == id) != null;

        }

        public BoardInfoViewModel GetBoardInfo(int id)
        {
            Team team = this.data.Teams.GetById(id);
            return Mapper.Map<Team, BoardInfoViewModel>(team);
        }

        public MembersViewModel GetAllMembers(int id)
        {
            MembersViewModel vm = new MembersViewModel {TeamId = id};
            IEnumerable<Student> members = this.data.Teams.GetById(id).Members;
            vm.Members = Mapper.Map<IEnumerable<Student>, IEnumerable<BoardMemberViewModel>>(members);
            return vm;
        }

        public EditTeamViewModel GetEditTeam(int id)
        {
            Team team = this.data.Teams.GetById(id);

            return Mapper.Map<Team, EditTeamViewModel>(team);
        }

        public void EditTeam(EditTeamBindingModel binding, int id)
        {
            var team =this.data.Teams.GetById(id);
            team.Description = binding.Description;

            this.data.SaveChanges();
        }
    }
}
