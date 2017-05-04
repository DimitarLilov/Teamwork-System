using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.ViewModels.Admin.Users;
using TeamworkSystem.Services.AdminServices;

namespace TeamworkSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        private AdminUsersService service;
        public UsersController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public UsersController(TeamworkSystemData data)
        {
            this.service = new AdminUsersService(data);
        }

        // GET: Admin/Users
        [Route]
        public ActionResult Index(int? page)
        {
            AdminAllUsersViewModel vm = this.service.GetAllUsers(page);

            return View(vm);
        }

    }
}
