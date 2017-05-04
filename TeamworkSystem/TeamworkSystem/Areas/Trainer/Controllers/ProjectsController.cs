using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TeamworkSystem.Data;
using TeamworkSystem.Models.ViewModels.Trainer.Projects;
using TeamworkSystem.Services.TrainerServices;

namespace TeamworkSystem.Areas.Trainer.Controllers
{
    [Authorize(Roles = "Trainer")]
    [RouteArea("Trainer")]
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private TrainerProjectsService service;
        public ProjectsController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public ProjectsController(TeamworkSystemData data)
        {
            this.service = new TrainerProjectsService(data);
        }
        // GET: Trainer/Projects
        [Route]
        public ActionResult Index(int? page)
        {
            var username = this.User.Identity.Name;
            TrainerAllProjectsViewModel vm = this.service.GrtAllProjects(page,username);
            return View(vm);
        }

        // GET: Trainer/Projects/Details/5
        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
            var username = this.User.Identity.Name;
            if (!this.service.LeadingCoursesProject(username, id))
            {
                return this.RedirectToAction("Index", "Projects");
            }
            TrainerProjectDetailsViewModel vm = this.service.GetProjectDetails(username,id);
            return View(vm);
        }

    }
}
