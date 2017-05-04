using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.ViewModels.Assistant.Home;
using TeamworkSystem.Services.AssistantServices;

namespace TeamworkSystem.Areas.Assistant.Controllers
{
    [Authorize(Roles = "Assistant")]
    [RouteArea("Assistant")]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private AssistantHomeService service;
        public HomeController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public HomeController(TeamworkSystemData data)
        {
            this.service = new AssistantHomeService(data);
        }
        // GET: Assistant/Home
        [Route]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            AssistantPanelViewModel vm = this.service.GetAssistantInfo(username);

            return View(vm);
        }

        
    }
}
