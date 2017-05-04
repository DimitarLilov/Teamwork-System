using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.ViewModels.Admin.Projects;

namespace TeamworkSystem.Services.AdminServices
{
    public class AdminProjectsService : Service
    {
        public AdminProjectsService(ITeamworkSystemData data) : base(data)
        {
        }

        public AdminAllProjectsViewModel GetAllProjects(int? page)
        {
            IEnumerable<Project> projects = this.data.Projects.GetAll();

            AdminAllProjectsViewModel vm = new AdminAllProjectsViewModel();
            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<AdminProjectViewModel>>(projects);

            var projectsPage = vm.Projects;
            var pager = new Pager(projectsPage.Count(), page);

            vm.Projects = projectsPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }

        public AdminDeleteProjectViewModel GetDeleteProject(int id)
        {
            Project project = this.data.Projects.GetById(id);

            return Mapper.Map<Project, AdminDeleteProjectViewModel>(project);
        }

        public void DeleteProject(int id)
        {
            var project = this.data.Projects.GetById(id);
            this.data.Projects.Delete(project);
            this.data.SaveChanges();
        }
    }
}
