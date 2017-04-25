using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private HomeService service;
        public HomeController()
            :this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public HomeController(TeamworkSystemData data)
        {
            this.service = new HomeService(data);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult GetImage()
        {
           string path = this.service.GetUserPhoto(this.User.Identity.Name);
            return Content(path);
        }
    }
}