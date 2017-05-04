using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.ViewModels.Trainer.Home;
using TeamworkSystem.Services.TrainerServices;

namespace TeamworkSystem.Areas.Trainer.Controllers
{
    [Authorize(Roles = "Trainer")]
    [RouteArea("Trainer")]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private TrainerHomeService service;
        public HomeController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public HomeController(TeamworkSystemData data)
        {
            this.service = new TrainerHomeService(data);
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
