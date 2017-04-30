using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models;
using TeamworkSystem.Models.BindingModels.Courses;
using TeamworkSystem.Models.BindingModels.Projects;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private ProjectsService service;
        public ProjectsController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public ProjectsController(TeamworkSystemData data)
        {
            this.service = new ProjectsService(data);
        }

        // GET: Projects
        [HttpGet]
        [Route]
        public ActionResult Index(int? page)
        {
            AllProjectsViewModel vm = this.service.GetAllProjects();

            var projects = vm.Projects;
            var pageSize = 30;
            var pager = new Pager(projects.Count(), page, pageSize);

            vm.Projects = projects.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return View(vm);
        }



        [HttpGet]
        [AllowAnonymous]
        [Route("{id:int}")]
        public ActionResult Show(int id)
        {
            ProjectInfoViewModel vm = this.service.GetProject(id);

            return this.View(vm);
        }

        [ChildActionOnly]
        [Route("{id:int}")]
        public ActionResult Points(int id)
        {
            string userName = this.User.Identity.Name;
            IEnumerable<string> assistents = this.service.GetAssistentsNames(id);
            string trainer = this.service.GetTreinerName(id);

            if (!this.service.IsActiveProject(id) || (!assistents.Contains(userName) && !trainer.Contains(userName)) || this.service.IsAssess(userName, id) )
            {
                return null;
            }

            IEnumerable<CriteriaViewModel> vm = this.service.GetProjectCriteria(id).ToList();

            return this.PartialView("_Points", vm);

        }

        [HttpPost]
        [Route("{id:int}")]
        public ActionResult Points(int id, IList<CriteriaBindingModel> binding)
        {
            string userName = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.service.GradeProject(userName, id, binding);
                return this.RedirectToAction("Show", new { id = id });
            }

            IEnumerable<string> assistents = this.service.GetAssistentsNames(id);
            string trainer = this.service.GetTreinerName(id);
            if (!assistents.Contains(userName) && !trainer.Contains(userName))
            {
                return null;
            }

            IEnumerable<CriteriaViewModel> vm = this.service.GetProjectCriteria(id).ToList();

            return this.PartialView("_Points", vm);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult Comment(int id)
        {
            IEnumerable<CommentViewModel> vm = this.service.GetComments(id);

            return this.PartialView("_Comment", vm);
        }

        [HttpPost]
        public ActionResult Comment(int id, CommentBindingModel binding)
        {
            string userName = this.User.Identity.Name;
            if (ModelState.IsValid)
            {
                this.service.AddComment(id, binding, userName);

            }

            return this.RedirectToAction("Show", new { id = id });
        }

    }
}