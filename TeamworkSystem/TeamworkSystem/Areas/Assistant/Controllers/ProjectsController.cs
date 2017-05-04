using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.ViewModels.Assistant.Projects;
using TeamworkSystem.Services.AssistantServices;

namespace TeamworkSystem.Areas.Assistant.Controllers
{
    [Authorize(Roles = "Assistant")]
    [RouteArea("Assistant")]
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private AssistantProjectsService service;
        public ProjectsController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public ProjectsController(TeamworkSystemData data)
        {
            this.service = new AssistantProjectsService(data);
        }

        // GET: Assistant/Projects
        [Route]
        public ActionResult Index(int? page)
        {
            var username = this.User.Identity.Name;
            AssistantAllProjectsViewModel vm = this.service.GetAllProjects(page, username);
            return View(vm);
        }

    }
}
