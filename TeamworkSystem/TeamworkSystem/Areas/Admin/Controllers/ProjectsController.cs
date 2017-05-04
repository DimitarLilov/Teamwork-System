﻿using System.Web.Mvc;
using TeamworkSystem.Data;
using TeamworkSystem.Models.BindingModels.Admin.Projects;
using TeamworkSystem.Models.ViewModels.Admin.Projects;
using TeamworkSystem.Services.AdminServices;

namespace TeamworkSystem.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    [RoutePrefix("Projects")]
    public class ProjectsController : Controller
    {
        private AdminProjectsService service;
        public ProjectsController()
            : this(new TeamworkSystemData(new TeamworkSystemContext()))
        {

        }

        public ProjectsController(TeamworkSystemData data)
        {
            this.service = new AdminProjectsService(data);
        }
        // GET: Admin/Projects
        [Route]
        public ActionResult Index(int? page)
        {
            AdminAllProjectsViewModel vm = this.service.GetAllProjects(page);
            return View(vm);
        }

        [Route("{id:int}/Delete")]
        public ActionResult Delete(int id)
        {
            AdminDeleteProjectViewModel vm = this.service.GetDeleteProject(id);
            return View(vm);
        }

        [HttpPost]
        [Route("{id:int}/Delete")]
        public ActionResult Delete(int id,AdminDeleteProjectBindingModel binding)
        {
            this.service.DeleteProject(binding.Id);

            return this.RedirectToAction("Index", "Projects");
        }
    }
}
