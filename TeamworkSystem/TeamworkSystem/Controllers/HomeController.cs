using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;
        public HomeController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public HomeController(TeamworkSystemData data)
        {
            this.service = new HomeService(data);
        }
        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ChildActionOnly]
        [Route("GetImage")]
        public ActionResult GetImage()
        {
            string path = this.service.GetUserPhoto(this.User.Identity.Name);

            return this.PartialView("_ProfileImage", path);
        }

        [ChildActionOnly]
        [Route("AdminPanel")]
        public ActionResult AdminPanel()
        {
            if (Request.IsAuthenticated && User.IsInRole("Admin"))
            {
                return this.PartialView("_AdminPanel");
            }
            return null;
        }

        [ChildActionOnly]
        [Route("AssistantPanel")]
        public ActionResult AssistantPanel()
        {
            if (Request.IsAuthenticated && User.IsInRole("Assistant"))
            {
                return this.PartialView("_AssistantPanel");
            }
            return null;
        }
        [ChildActionOnly]
        [Route("TrainerPanel")]
        public ActionResult TrainerPanel()
        {
            if (Request.IsAuthenticated && User.IsInRole("Trainer"))
            {
                return this.PartialView("_TrainerPanel");
            }
            return null;
        }
    }
}