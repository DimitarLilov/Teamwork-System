using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TeamworkSystem.Data;
using TeamworkSystem.Models;
using TeamworkSystem.Models.ViewModels.Users;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        private UsersService service;
        public UsersController()
            :this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public UsersController(TeamworkSystemData data) 
        {
            this.service = new UsersService(data);
        }

        [HttpGet]
        [Route("{username}")]
        public ActionResult Profile(string username)
        {
            if (username.IsNullOrWhiteSpace() || username == this.User.Identity.Name)
            {
                return RedirectToAction("MyProfile", "Users");
            }
            ProfileViewModel vm = this.service.GetUserInfo(username);
            return this.View(vm);
        }

        [HttpGet]
        [Route("Profile")]
        [Authorize]
        public ActionResult MyProfile()
        {
            string username = this.User.Identity.Name;

            ProfileViewModel vm = this.service.GetUserInfo(username);
            return this.View(vm);
        }

        [HttpGet]
        [Route("Edit")]
        [Authorize]
        public ActionResult Edit()
        {
            string username = this.User.Identity.Name;

            EditUserViewModel vm = this.service.EditUser(username);
            return this.View(vm);
        }

        [HttpGet]
        [Route("{username}/Teams")]
        [Authorize]
        public ActionResult Teams(string username, int? page)
        {
            AllUsersTeamsViewModel vm = this.service.GetAllUsersTeams(username);

            var teams = vm.Teams;
            var pager = new Pager(teams.Count(), page);

            vm.Teams = teams.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        [HttpGet]
        [Route("{username}/Projects")]
        [Authorize]
        public ActionResult Projects(string username, int? page)
        {
            AllUsersProjectsViewModel vm = this.service.GetAllUsersProjects(username);

            var projects = vm.Projects;
            var pager = new Pager(projects.Count(), page);

            vm.Projects = projects.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        [HttpGet]
        [Route("{username}/Collaborators")]
        [Authorize]
        public ActionResult Collaborators(string username, int? page)
        {
            AllUsersCollaboratorsViewModel vm = this.service.GetAllUsersCollaborators(username);

            var collaborators = vm.Collaborators;
            var pager = new Pager(collaborators.Count(), page);

            vm.Collaborators = collaborators.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

    }
}