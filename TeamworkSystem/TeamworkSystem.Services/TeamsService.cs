using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.ViewModels.Teams;

namespace TeamworkSystem.Services
{
    public class TeamsService: Service
    {
        public TeamsService(ITeamworkSystemData data) : base(data)
        {
            
        }

        public TeamViewModel GetTeamInfo(int id)
        {
            TeamViewModel vm = new TeamViewModel();

            Team team = this.data.Teams.GetById(id);
            TeamInfoViewModel teamInfo = Mapper.Map<Team, TeamInfoViewModel>(team);
            vm.Team = teamInfo;

            IEnumerable<Project> projects = team.Projects.Take(4);
            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectTeamViewModel>>(projects);

            IEnumerable<Course> courses = team.Projects.Select(p => p.Course).Take(4).Distinct();
            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseTeamViewModel>>(courses);

            return vm;
        }


        public IEnumerable<string> GetMembersName(int id)
        {
            return this.data.Teams.FindByPredicate(t => t.Id == id).Members.Select(m => m.IdentityUser.UserName);
        }

        public AllTeamsProjectsViewModel GetAllProjects(int id)
        {
            AllTeamsProjectsViewModel viewModel = new AllTeamsProjectsViewModel();

            Team team = this.data.Teams.GetById(id);
            TeamInfoViewModel teamInfo = Mapper.Map<Team, TeamInfoViewModel>(team);
            viewModel.Team = teamInfo;

            IEnumerable<Project> project = this.data.Teams.FindByPredicate(t => t.Id == id).Projects;

            viewModel.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectTeamViewModel>>(project);

            return viewModel;
        }

        public AllTeamsCoursesViewModel GetAllCourses(int id)
        {
            AllTeamsCoursesViewModel viewModel = new AllTeamsCoursesViewModel();

            Team team = this.data.Teams.GetById(id);
            TeamInfoViewModel teamInfo = Mapper.Map<Team, TeamInfoViewModel>(team);
            viewModel.Team = teamInfo;

            IEnumerable<Course> courses = this.data.Teams.FindByPredicate(t => t.Id == id).Projects.Select(p => p.Course).Distinct();

            viewModel.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseTeamViewModel>>(courses);

            return viewModel;
        }
    }
}
