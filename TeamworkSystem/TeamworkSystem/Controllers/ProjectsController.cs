using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private ProjectsService service;
        public ProjectsController()
            :this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public ProjectsController(TeamworkSystemData data)
        {
            this.service = new ProjectsService(data);
        }
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }
    }
}