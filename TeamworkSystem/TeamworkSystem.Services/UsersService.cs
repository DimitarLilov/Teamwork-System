using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models;
using TeamworkSystem.Models.BindingModels.Users;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.Enums;
using TeamworkSystem.Models.ViewModels.Users;
using TeamworkSystem.Services.Contracts;
using TeamworkSystem.Utillities.Constants;

namespace TeamworkSystem.Services
{
    public class UsersService : Service, IUsersService
    {
        public UsersService(ITeamworkSystemData data) : base(data)
        {

        }

        public ProfileViewModel GetUserProfile(string username)
        {
            var user = this.data.User.FindByPredicate(s => s.UserName == username);
            ProfileViewModel viewModel = Mapper.Map<ApplicationUser, ProfileViewModel>(user);

            Student student = this.data.Students.FindByPredicate(s => s.IdenityUserId == user.Id);

            IEnumerable<Project> project = student.Teams.SelectMany(t => t.Projects.OrderByDescending(p => p.Grade)).Where(p => p.IsPublic).Take(4);
            viewModel.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectUsersViewModel>>(project);

            IEnumerable<Team> teams = student.Teams.Take(4);
            viewModel.Teams = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamUserViewModel>>(teams);

            IEnumerable<Student> colaboration =
                student.Teams.SelectMany(t => t.Members.Where(m => m.IdenityUserId != user.Id)).Distinct().Take(4);


            viewModel.Collaborators =
                Mapper.Map<IEnumerable<Student>, IEnumerable<CollaborationUserViewModel>>(colaboration);


            return viewModel;
        }

        public EditUserViewModel GetEditUser(string username)
        {
            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);
            EditUserViewModel vm = Mapper.Map<ApplicationUser, EditUserViewModel>(user);
            return vm;
        }

        public AllUsersProjectsViewModel GetAllUsersProjects(string username)
        {
            AllUsersProjectsViewModel viewModel = new AllUsersProjectsViewModel { Username = username };
            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);

            Student student = this.data.Students.FindByPredicate(s => s.IdenityUserId == user.Id);
            IEnumerable<Project> project = student.Teams.SelectMany(t => t.Projects).Where(p => p.IsPublic);
            viewModel.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectUsersViewModel>>(project);

            return viewModel;
        }

        public AllUsersTeamsViewModel GetAllUsersTeams(string username, int? page)
        {
            AllUsersTeamsViewModel viewModel = new AllUsersTeamsViewModel { Username = username };

            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);
            Student student = this.data.Students.FindByPredicate(s => s.IdenityUserId == user.Id);

            IEnumerable<Team> teams = student.Teams;
            viewModel.Teams = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamUserViewModel>>(teams);

            var teamsPge = viewModel.Teams;
            var pager = new Pager(teams.Count(), page);

            viewModel.Teams = teamsPge.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            viewModel.Pager = pager;

            return viewModel;
        }

        public AllUsersCollaboratorsViewModel GetAllUsersCollaborators(string username)
        {
            AllUsersCollaboratorsViewModel viewModel = new AllUsersCollaboratorsViewModel { Username = username };
            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);

            Student student = this.data.Students.FindByPredicate(s => s.IdenityUserId == user.Id);
            IEnumerable<Student> teams = student.Teams.SelectMany(t => t.Members.Where(m => m.IdenityUserId != user.Id)).Distinct();
            viewModel.Collaborators = Mapper.Map<IEnumerable<Student>, IEnumerable<CollaborationUserViewModel>>(teams);

            return viewModel;
        }

        public bool ContainsUser(string username)
        {
            return this.data.User.FindByPredicate(u => u.UserName == username) != null;
        }

        public UserInfoViewModel GetUserInfo(string username)
        {
            ApplicationUser user = this.data.User.FindByPredicate(u => u.UserName == username);
            return Mapper.Map<ApplicationUser, UserInfoViewModel>(user);
        }

        public void EditUser(string username, EditUserBindingModel binding)
        {
            var user = data.User.FindByPredicate(u => u.UserName == username);
            user.FirstName = binding.FirstName;
            user.LastName = binding.LastName;
            user.WebSite = binding.WebSite;
            user.SoftUniProfile = binding.SoftuniProfile;
            user.PhoneNumber = binding.PhoneNumber;
            user.AboutMe = binding.AboutMe;
            user.Country = binding.Country;
            user.Town = binding.Town;
            user.Gender = (Gender)Enum.Parse(typeof(Gender), binding.Gender);
            user.BirthDate = binding.BirthDate;
            user.Facebook = binding.Facebook;
            user.Twitter = binding.Twitter;
            user.GooglePlus = binding.GooglePlus;
            user.LinkedIn = binding.LinkedIn;
            user.GitHub = binding.GitHub;
            user.StackOverflow = binding.StackOverflow;
            user.Instagram = binding.Instagram;
            user.Skype = binding.Skype;

            this.data.SaveChanges();
        }

        public void AddImage(string pic, string username)
        {
            var path = PathConstants.ProfilePath + pic;
            Photo photo = new Photo()
            {
                UrlPthoto = path
            };

            this.data.Photos.Insert(photo);
            this.data.User.FindByPredicate(u => u.UserName == username).ProfilePhoto = photo;
            this.data.SaveChanges();
        }

        public IEnumerable<string> GettUsernames()
        {
            return this.data.User.GetAll().Select(u => u.UserName.ToLower());
        }
    }
}