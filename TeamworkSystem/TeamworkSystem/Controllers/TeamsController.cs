using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models;
using TeamworkSystem.Models.BindingModels.Teams;
using TeamworkSystem.Models.ViewModels.Teams;
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

        // GET: Teams
        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult Show(int id)
        {
            TeamViewModel vm = this.service.GetTeam(id);
            return this.View(vm);
        }

        [HttpGet]
        [Route("{id:int}/Projects")]
        public ActionResult Projects(int id, int? page)
        {
            AllTeamsProjectsViewModel vm = this.service.GetAllProjects(id);


            var projects = vm.Projects;
            var pager = new Pager(projects.Count(), page);

            vm.Projects = projects.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        [HttpGet]
        [Route("{id:int}/Courses")]
        public ActionResult Courses(int id, int? page)
        {
            AllTeamsCoursesViewModel vm = this.service.GetAllCourses(id);


            var courses = vm.Courses;
            var pager = new Pager(courses.Count(), page);

            vm.Courses = courses.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return this.View(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}/Dashboard")]
        public ActionResult Dashboard(int id)
        {
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return RedirectToAction("Show", "Teams", new { id = id });
            }

            DashboardInfoViewModel vm = this.service.GetTeamDashboard(id);
            return this.View(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}/Tasks")]
        public ActionResult Tasks(int id)
        {
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return this.RedirectToAction("Show", "Teams", new { id = id });
            }

            TeamTasksViewModel vm = this.service.GetTeamTasks(id);
            return this.View(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}/Add/Member")]
        public ActionResult AddMember(int id)
        {
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return this.RedirectToAction("Show", "Teams", new { id = id });
            }

            AddMembersViewModel vm = new AddMembersViewModel { Team = this.service.GetTeamInfo(id) };
            return this.View(vm);
        }


        [HttpPost]
        [Authorize]
        [Route("{id:int}/Add/Member")]
        public ActionResult AddMember(int id,AddMemberBindingModel binding)
        {
            var user = this.service.ContainsUser(binding);
            if (ModelState.IsValid && user)
            {
                
                this.service.AddMember(id, binding);
            }
            
            return this.RedirectToAction("AddMember", "Teams", new { id = id });
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}/Add/Task")]
        public ActionResult AddTask(int id)
        {
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return this.RedirectToAction("Show", "Teams", new { id = id });
            }

            AddTaskViewModel vm = this.service.GetTeamInfoForTask(id);

            return this.View(vm);
        }

        [HttpPost]
        [Authorize]
        [Route("{id:int}/Add/Task")]
        public ActionResult AddTask(int id, AddTaskBindingModel binding)
        {
            var currentUser = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.service.AddTask(id, binding, currentUser);
                return this.RedirectToAction("Tasks", "Teams", new {id = id});
            }

            AddTaskViewModel vm = this.service.GetTeamInfoForTask(id);

            return this.View(vm);
        }

        [HttpGet]
        [Authorize]
        [Route("Create")]
        public ActionResult Create()
        {
            CreateTeamViewModel vm = new CreateTeamViewModel();
            return this.View(vm);
        }


        [HttpPost]
        [Authorize]
        [Route("Create")]
        public ActionResult Create(CreateTeamBindingModel binding)
        {
            var username = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                int id = this.service.CreateTeam(binding, username);

                return this.RedirectToAction("AddMember", "Teams",new {id = id});
            }
            CreateTeamViewModel vm = new CreateTeamViewModel();
            return this.View(vm);

        }

        [HttpPost]
        public JsonResult AutoCompleteUser(string prefix)
        {
            IEnumerable<string> usernames = this.service.GettUsernames();

            var username = usernames.Where(u => u.StartsWith(prefix.ToLower()));

            return Json(username, JsonRequestBehavior.AllowGet);
        }

    }
}