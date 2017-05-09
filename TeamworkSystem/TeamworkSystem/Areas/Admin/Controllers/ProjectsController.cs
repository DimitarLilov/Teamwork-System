namespace TeamworkSystem.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using TeamworkSystem.Attributes;
    using TeamworkSystem.Models.BindingModels.Admin.Projects;
    using TeamworkSystem.Models.ViewModels.Admin.Projects;
    using TeamworkSystem.Services.Contracts.Admin;

    [CustomAuthorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private IAdminProjectsService service;

        public ProjectsController(IAdminProjectsService service)
        {
            this.service = service;
        }

        // GET: Admin/Projects
        [Route]
        public ActionResult Index(int? page)
        {
            AdminAllProjectsViewModel vm = this.service.GetAllProjects(page);
            return this.View(vm);
        }

        [Route("{id:int}/Delete")]
        public ActionResult Delete(int id)
        {
            AdminDeleteProjectViewModel vm = this.service.GetDeleteProject(id);
            return this.View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Delete")]
        public ActionResult Delete(int id, AdminDeleteProjectBindingModel binding)
        {
            this.service.DeleteProject(binding.Id);

            return this.RedirectToAction("Index", "Projects");
        }
    }
}
