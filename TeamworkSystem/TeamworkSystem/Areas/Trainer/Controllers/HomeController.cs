using System.Web.Mvc;
using TeamworkSystem.Attributes;
using TeamworkSystem.Models.ViewModels.Trainer.Home;
using TeamworkSystem.Services.Contracts.Trainers;

namespace TeamworkSystem.Areas.Trainer.Controllers
{
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

        [Route]
        // GET: Trainer/Home
        public ActionResult Index()
        {
            var username = this.User.Identity.Name;
            TrainerPanelViewModel vm = this.service.GetTrainerInfo(username);
            return View(vm);
        }

    }
}
