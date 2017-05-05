using System.Web.Mvc;
using TeamworkSystem.Attributes;
using TeamworkSystem.Models.ViewModels.Assistant.Home;
using TeamworkSystem.Services.Contracts.Assistans;

namespace TeamworkSystem.Areas.Assistant.Controllers
{
    [CustomAuthorize(Roles = "Assistant")]
    [RouteArea("Assistant")]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private IAssistantHomeService service;

        public HomeController(IAssistantHomeService service)
        {
            this.service = service;
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
