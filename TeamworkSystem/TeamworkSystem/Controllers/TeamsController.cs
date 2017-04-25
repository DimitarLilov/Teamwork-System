using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models;
using TeamworkSystem.Models.ViewModels.Teams;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Teams")]
    public class TeamsController : Controller
    {
        private TeamsService service;
        public TeamsController()
            :this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public TeamsController(TeamworkSystemData data)
        {
            this.service = new TeamsService(data);
        }

        // GET: Teams
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult ShowTeam(int id)
        {
            TeamViewModel vm = this.service.GetTeamInfo(id);
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
        [Route("{id:int}/dashboard")]
        public ActionResult Dashboard(int id)
        {
            IEnumerable<string> members = this.service.GetMembersName(id);
            if (!members.Contains(this.User.Identity.Name))
            {
                return RedirectToAction("ShowTeam", "Teams",id);
            }

            //TeamViewModel vm = this.service.GetTeamInfo(id);
            return this.View();
        }
    }
}