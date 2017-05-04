using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.ViewModels.Admin.Teams;
using TeamworkSystem.Services.AdminServices;

namespace TeamworkSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Teams")]
    public class TeamsController : Controller
    {
        private AdminTeamsService service;

        public TeamsController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public TeamsController(TeamworkSystemData data)
        {
            this.service = new AdminTeamsService(data);
        }

        [Route]
        // GET: Admin/Teams
        public ActionResult Index(int? page)
        {
            AdminAllTeamsViewModel vm = this.service.GetAllTeams(page);
            return View(vm);
        }

        // GET: Admin/Teams/Details/5
        [Route("{id:int}/Details")]
        public ActionResult Details(int id)
        {
            AdminTeamDetailsViewModel vm = this.service.GetTeamDetails(id);
            return View(vm);
        }

    }
}
