using TeamworkSystem.Models.ViewModels.Admin.Projects;

namespace TeamworkSystem.Services.Contracts.Admin
{
    public interface IAdminProjectsService
    {
        AdminAllProjectsViewModel GetAllProjects(int? page);
        AdminDeleteProjectViewModel GetDeleteProject(int id);
        void DeleteProject(int id);
    }
}
