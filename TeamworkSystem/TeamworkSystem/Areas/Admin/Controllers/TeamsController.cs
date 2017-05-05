using System.Web.Mvc;
using TeamworkSystem.Attributes;
using TeamworkSystem.Models.ViewModels.Admin.Teams;
using TeamworkSystem.Services.Contracts.Admin;

namespace TeamworkSystem.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Teams")]
    public class TeamsController : Controller
    {
        private IAdminTeamsService service;

        public TeamsController(IAdminTeamsService service)
        {
            this.service = service;
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
