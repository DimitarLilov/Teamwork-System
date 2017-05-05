using System.Web.Mvc;
using TeamworkSystem.Attributes;
using TeamworkSystem.Models.ViewModels.Assistant.Projects;
using TeamworkSystem.Services.Contracts.Assistans;

namespace TeamworkSystem.Areas.Assistant.Controllers
{
    [CustomAuthorize(Roles = "Assistant")]
    [RouteArea("Assistant")]
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private IAssistantProjectsService service;

        public ProjectsController(IAssistantProjectsService service)
        {
            this.service = service;
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
