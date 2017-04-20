using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Services;

namespace TeamworkSystem.Controllers
{
    [RoutePrefix("Teams")]
    public class TeamsController : Controller
    {
        private TeamsService service;
        public TeamsController()
            :this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public TeamsController(TeamworkSystemData data)
        {
            this.service = new TeamsService(data);
        }

        // GET: Teams
        public ActionResult Index()
        {
            return View();
        }
    }
}