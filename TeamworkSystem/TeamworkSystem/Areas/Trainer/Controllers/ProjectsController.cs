namespace TeamworkSystem.Areas.Trainer.Controllers
{
    using System.Web.Mvc;

    using TeamworkSystem.Attributes;
    using TeamworkSystem.Models.ViewModels.Trainer.Projects;
    using TeamworkSystem.Services.Contracts.Trainers;

    [CustomAuthorize(Roles = "Trainer")]
    [RouteArea("Trainer")]
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private ITrainerProjectsService service;

        public ProjectsController(ITrainerProjectsService servicea)
        {
            this.service = servicea;
        }

        // GET: Trainer/Projects
        [Route]
        public ActionResult Index(int? page)
        {
            var username = this.User.Identity.Name;
            TrainerAllProjectsViewModel vm = this.service.GrtAllProjects(page, username);
            return this.View(vm);
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

            TrainerProjectDetailsViewModel vm = this.service.GetProjectDetails(username, id);
            return this.View(vm);
        }
    }
}
