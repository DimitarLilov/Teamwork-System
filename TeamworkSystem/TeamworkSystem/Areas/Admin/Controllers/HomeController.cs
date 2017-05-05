using System.Web.Mvc;
using TeamworkSystem.Attributes;
using TeamworkSystem.Models.ViewModels.Admin.Home;
using TeamworkSystem.Services.Contracts.Admin;

namespace TeamworkSystem.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        private IAdminHomeService service;

        public HomeController(IAdminHomeService service)
        {
            this.service = service;
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