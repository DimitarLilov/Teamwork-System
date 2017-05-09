namespace TeamworkSystem.Areas.Assistant.Controllers
{
    using System.Web.Mvc;

    using TeamworkSystem.Attributes;
    using TeamworkSystem.Models.ViewModels.Assistant.Home;
    using TeamworkSystem.Services.Contracts.Assistans;

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
            var username = this.User.Identity.Name;
            AssistantPanelViewModel vm = this.service.GetAssistantInfo(username);

            return this.View(vm);
        }
    }
}
