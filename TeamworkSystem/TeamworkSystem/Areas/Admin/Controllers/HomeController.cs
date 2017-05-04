using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.ViewModels.Admin.Home;
using TeamworkSystem.Services.AdminServices;

namespace TeamworkSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private AdminHomeService service;
        public HomeController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public HomeController(TeamworkSystemData data)
        {
            this.service = new AdminHomeService(data);
        }

        [Route()]
        // GET: Admin/Home
        public ActionResult Index()
        {
            AdminPanelViewModel vm = this.service.GetAdminPanel();
            return View(vm);
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
    }
}