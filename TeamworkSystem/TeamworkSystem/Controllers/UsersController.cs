using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Users")]
    public class UsersController : Controller
    {
        private UsersService service;
        public UsersController()
            :this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public UsersController(TeamworkSystemData data) 
        {
            this.service = new UsersService(data);
        }
        
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
    }
}