using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Users;

namespace TeamworkSystem.Services
{
    public class UsersService : Service
    {
        public UsersService(ITeamworkSystemData data) : base(data)
        {

        }

        public ProfileViewModel GetUserInfo(string username)
        {
            var user = this.data.User.FindByPredicate(s => s.UserName == username);
            ProfileViewModel viewModel = Mapper.Map<ApplicationUser, ProfileViewModel>(user);

            Student student = this.data.Students.FindByPredicate(s => s.IdenityUserId == user.Id);

            IEnumerable<Project> project = student.Teams.SelectMany(t => t.Projects.OrderByDescending(p => p.Grade)).Take(4);
            viewModel.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectUsersViewModel>>(project);

            IEnumerable<Team> teams = student.Teams.Take(4);
            viewModel.Teams = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamUserViewModel>>(teams);

            IEnumerable<Student> colaboration =
                student.Teams.SelectMany(t => t.Members.Where(m => m.IdenityUserId != user.Id)).Distinct().Take(4);


            viewModel.Collaborators =
                Mapper.Map<IEnumerable<Student>, IEnumerable<CollaborationUserViewModel>>(colaboration);


            return viewModel;
        }

        public EditUserViewModel EditUser(string username)
        {
            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);
            EditUserViewModel vm = Mapper.Map<ApplicationUser, EditUserViewModel>(user);
            return vm;
        }

        public AllUsersProjectsViewModel GetAllUsersProjects(string username)
        {
            AllUsersProjectsViewModel viewModel = new AllUsersProjectsViewModel();
            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);
            viewModel.User = Mapper.Map<ApplicationUser, UserInfoViewModel>(user);

            Student student = this.data.Students.FindByPredicate(s => s.IdenityUserId == user.Id);
            IEnumerable<Project> project = student.Teams.SelectMany(t => t.Projects);
            viewModel.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectUsersViewModel>>(project);

            return viewModel;
        }

        public AllUsersTeamsViewModel GetAllUsersTeams(string username)
        {
            AllUsersTeamsViewModel viewModel = new AllUsersTeamsViewModel();
            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);
            viewModel.User = Mapper.Map<ApplicationUser, UserInfoViewModel>(user);

            Student student = this.data.Students.FindByPredicate(s => s.IdenityUserId == user.Id);
            IEnumerable<Team> teams = student.Teams;
            viewModel.Teams = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamUserViewModel>>(teams);

            return viewModel;
        }

        public AllUsersCollaboratorsViewModel GetAllUsersCollaborators(string username)
        {
            AllUsersCollaboratorsViewModel viewModel = new AllUsersCollaboratorsViewModel();
            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);
            viewModel.User = Mapper.Map<ApplicationUser, UserInfoViewModel>(user);

            Student student = this.data.Students.FindByPredicate(s => s.IdenityUserId == user.Id);
            IEnumerable<Student> teams = student.Teams.SelectMany(t => t.Members.Where(m => m.IdenityUserId != user.Id)).Distinct();
            viewModel.Collaborators = Mapper.Map<IEnumerable<Student>, IEnumerable<CollaborationUserViewModel>>(teams);

            return viewModel;
        }
    }
}