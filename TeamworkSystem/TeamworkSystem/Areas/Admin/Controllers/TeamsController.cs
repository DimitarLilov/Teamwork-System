namespace TeamworkSystem.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using TeamworkSystem.Attributes;
    using TeamworkSystem.Models.ViewModels.Admin.Teams;
    using TeamworkSystem.Services.Contracts.Admin;

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

        // GET: Admin/Teams
        [Route]
        public ActionResult Index(int? page)
        {
            AdminAllTeamsViewModel vm = this.service.GetAllTeams(page);
            return this.View(vm);
        }

        // GET: Admin/Teams/Details/5
        [Route("{id:int}/Details")]
        public ActionResult Details(int id)
        {
            AdminTeamDetailsViewModel vm = this.service.GetTeamDetails(id);
            return this.View(vm);
        }
    }
}
