namespace TeamworkSystem.Areas.Trainer.Controllers
{
    using System.Web.Mvc;

    using TeamworkSystem.Attributes;
    using TeamworkSystem.Models.ViewModels.Trainer.Home;
    using TeamworkSystem.Services.Contracts.Trainers;

    [CustomAuthorize(Roles = "Trainer")]
    [RouteArea("Trainer")]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private ITrainerHomeService service;

        public HomeController(ITrainerHomeService service)
        {
            this.service = service;
        }

        // GET: Trainer/Home
        [Route]
        public ActionResult Index()
        {
            var username = this.User.Identity.Name;
            TrainerPanelViewModel vm = this.service.GetTrainerInfo(username);
            return this.View(vm);
        }
    }
}
