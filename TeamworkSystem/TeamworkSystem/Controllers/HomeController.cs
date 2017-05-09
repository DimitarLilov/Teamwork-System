namespace TeamworkSystem.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using TeamworkSystem.Models.ViewModels.Home;
    using TeamworkSystem.Services.Contracts;

    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [Route]
        public ActionResult Index()
        {
            IEnumerable<TopProjectsViewModel> vm = this.service.GetTopProjects();
            return this.View(vm);
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
            if (this.Request.IsAuthenticated && this.User.IsInRole("Admin"))
            {
                return this.PartialView("_AdminPanel");
            }

            return null;
        }

        [ChildActionOnly]
        [Route("AssistantPanel")]
        public ActionResult AssistantPanel()
        {
            if (this.Request.IsAuthenticated && this.User.IsInRole("Assistant"))
            {
                return this.PartialView("_AssistantPanel");
            }

            return null;
        }

        [ChildActionOnly]
        [Route("TrainerPanel")]
        public ActionResult TrainerPanel()
        {
            if (this.Request.IsAuthenticated && this.User.IsInRole("Trainer"))
            {
                return this.PartialView("_TrainerPanel");
            }

            return null;
        }
    }
}