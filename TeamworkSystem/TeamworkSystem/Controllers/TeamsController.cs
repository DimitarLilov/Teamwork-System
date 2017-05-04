﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models;
using TeamworkSystem.Models.BindingModels.Teams;
using TeamworkSystem.Models.ViewModels.Teams;
using TeamworkSystem.Models.ViewModels.Teams.Board;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Teams")]
    public class TeamsController : Controller
    {
        private TeamsService service;
        public TeamsController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public TeamsController(TeamworkSystemData data)
        {
            this.service = new TeamsService(data);
        }

        //GET : /Teams/Create
        [HttpGet]
        [Authorize]
        [Route("Create")]
        public ActionResult Create()
        {
            CreateTeamViewModel vm = new CreateTeamViewModel();
            return this.View(vm);
        }

        //Post : /Teams/Create
        [HttpPost]
        [Authorize]
        [Route("Create")]
        public ActionResult Create(CreateTeamBindingModel binding)
        {
            var username = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                int id = this.service.CreateTeam(binding, username);

                return this.RedirectToAction("AddMember", "Teams", new { id = id });
            }
            CreateTeamViewModel vm = new CreateTeamViewModel();
            return this.View(vm);

        }

        //GET: /Teams/Id
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Show(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }
            TeamViewModel vm = this.service.GetTeam(id);
            return this.View(vm);
        }

        //GET : /Teams/Id/Edit
        [HttpGet]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }
            var username = this.User.Identity.Name;
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(username))
            {
                return RedirectToAction("Show", "Teams", new { id = id });
            }

            EditTeamViewModel vm = this.service.GetEditTeam(id);

            return this.View(vm);
        }

        //POST : /Teams/Id/Edit
        [HttpPost]
        [Route("{id:int}/Edit")]
        public ActionResult Edit(int id,EditTeamBindingModel binding)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }
            var username = this.User.Identity.Name;
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(username))
            {
                return RedirectToAction("Show", "Teams", new { id = id });
            }

            if (ModelState.IsValid)
            {
                this.service.EditTeam(binding,id);
            }

            EditTeamViewModel vm = this.service.GetEditTeam(id);

            return this.View(vm);
        }

        //GET : /Teams/Id/Projects
        [HttpGet]
        [Route("{id:int}/Projects")]
        public ActionResult Projects(int id, int? page)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            AllTeamsProjectsViewModel vm = this.service.GetAllProjects(id);


            var projects = vm.Projects;
            var pager = new Pager(projects.Count(), page);

            vm.Projects = projects.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        //GET : /Teams/Id/Courses
        [HttpGet]
        [Route("{id:int}/Courses")]
        public ActionResult Courses(int id, int? page)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            AllTeamsCoursesViewModel vm = this.service.GetAllTaemsCourses(id);


            var courses = vm.Courses;
            var pager = new Pager(courses.Count(), page);

            vm.Courses = courses.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        //GET : /Teams/Id/Board
        [HttpGet]
        [Authorize]
        [Route("{id:int}/Board")]
        public ActionResult Board(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            var username = this.User.Identity.Name;
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(username))
            {
                return RedirectToAction("Show", "Teams", new { id = id });
            }

            BoardViewModel vm = this.service.GetTeamBoard(id, username);
            return this.View(vm);
        }

        //GET : /Teams/Id/Board/Projects
        [HttpGet]
        [Authorize]
        [Route("{id:int}/Board/Projects")]
        public ActionResult BoardProjects(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return RedirectToAction("Show", "Teams", new { id = id });
            }

            BoardProjectsViewModel vm = this.service.GetTeamBoardProjects(id);
            return this.View(vm);
        }

        //GET : /Teams/Id/Board/Tasks
        [HttpGet]
        [Authorize]
        [Route("{id:int}/Board/Tasks")]
        public ActionResult Tasks(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return this.RedirectToAction("Show", "Teams", new { id = id });
            }

            TeamTasksViewModel vm = this.service.GetTeamTasks(id);
            return this.View(vm);
        }
        //GET : /Teams/Id/Board/Members
        [HttpGet]
        [Authorize]
        [Route("{id:int}/Board/Member")]
        public ActionResult Members(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return this.RedirectToAction("Show", "Teams", new { id = id });
            }

            MembersViewModel vm = this.service.GetAllMembers(id);
            return this.View(vm);
        }

        //GET : /Teams/Id/Add/Member
        [HttpGet]
        [Authorize]
        [Route("{id:int}/Add/Member")]
        public ActionResult AddMember(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return this.RedirectToAction("Show", "Teams", new { id = id });
            }

            AddMembersViewModel vm = new AddMembersViewModel { TeamId = id };
            return this.View(vm);
        }

        //POST : /Teams/Id/Add/Member
        [HttpPost]
        [Authorize]
        [Route("{id:int}/Add/Member")]
        public ActionResult AddMember(int id,AddMemberBindingModel binding)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            var user = this.service.ContainsUser(binding);
            if (ModelState.IsValid && user)
            {
                
                this.service.AddMember(id, binding);
            }

            AddMembersViewModel vm = new AddMembersViewModel { TeamId = id };
            return this.View(vm);
        }

        //GET : /Teams/Id/Add/Project
        [HttpGet]
        [Authorize]
        [Route("{id:int}/Add/Project")]
        public ActionResult CreateProject(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return this.RedirectToAction("Show", "Teams", new { id = id });
            }

            AddProjectViewModel vm = new AddProjectViewModel
            {
                TeamId = id,
                Course = this.service.GetAllCourses()
            };

            return this.View(vm);
        }

        //POST: /Teams/Id/Add/Project
        [HttpPost]
        [Authorize]
        [Route("{id:int}/Add/Project")]
        public ActionResult CreateProject(int id,AddProjectBindingModel binding)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                this.service.CreateProject(id, binding);
                return this.RedirectToAction("BoardProjects", new {id = id});
            }

            AddProjectViewModel vm = new AddProjectViewModel
            {
                TeamId = id,
                Course = this.service.GetAllCourses()
            };

            return this.View(vm);
        }


        //GET: /Teams/Id/Add/Task
        [HttpGet]
        [Authorize]
        [Route("{id:int}/Add/Task")]
        public ActionResult AddTask(int id)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return this.RedirectToAction("Show", "Teams", new { id = id });
            }

            AddTaskViewModel vm = this.service.GetTeamInfoForTask(id);

            return this.View(vm);
        }

        //POST : /Teams/Id/Add/Task
        [HttpPost]
        [Authorize]
        [Route("{id:int}/Add/Task")]
        public ActionResult AddTask(int id, AddTaskBindingModel binding)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            var currentUser = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.service.AddTask(id, binding, currentUser);
                return this.RedirectToAction("Tasks", "Teams", new {id = id});
            }

            AddTaskViewModel vm = this.service.GetTeamInfoForTask(id);

            return this.View(vm);
        }

        //POST : /Teams/Id/Tasks/Complete
        [HttpPost]
        [Authorize]
        [Route("{id:int}/Tasks/Complete")]
        public ActionResult Complete(int id, CompleteTasksBindingModel binding)
        {
            if (!this.service.ContainsTeam(id))
            {
                return this.HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                this.service.CompleteTasks(binding);
            }

            return this.RedirectToAction("Tasks", new {id = id});

        }

        [Authorize]
        [ChildActionOnly]
        [Route("BoardInfo")]
        public ActionResult BoardInfo(int id)
        {
            BoardInfoViewModel vm = this.service.GetBoardInfo(id);

            return this.PartialView("_BoardInfo", vm);
        }

        [ChildActionOnly]
        [Route("TeamInfo")]
        public ActionResult TeamInfo(int id)
        {
            TeamInfoViewModel vm = this.service.GetTeamInfo(id);

            return this.PartialView("_TeamInfo", vm);
        }

        [HttpPost]
        [Route("AutoCompleteUser")]
        public JsonResult AutoCompleteUser(string prefix)
        {
            IEnumerable<string> usernames = this.service.GettUsernames();

            var username = usernames.Where(u => u.StartsWith(prefix.ToLower()));

            return Json(username, JsonRequestBehavior.AllowGet);
        }

        [ChildActionOnly]
        [Route("GoToTeamBoard")]
        public ActionResult GoToTeamBoard(int id)
        {
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (members.Contains(this.User.Identity.Name))
            {
                return this.PartialView("_TeamBoardButton", id);
            }

            return null;
        }

    }
}