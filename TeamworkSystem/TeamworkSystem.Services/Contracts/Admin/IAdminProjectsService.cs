namespace TeamworkSystem.Services.Contracts.Admin
{
    using TeamworkSystem.Models.ViewModels.Admin.Projects;

    public interface IAdminProjectsService
    {
        AdminAllProjectsViewModel GetAllProjects(int? page);

        AdminDeleteProjectViewModel GetDeleteProject(int id);

        void DeleteProject(int id);
    }
}
