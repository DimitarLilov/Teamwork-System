using TeamworkSystem.Models.ViewModels.Assistant.Projects;

namespace TeamworkSystem.Services.Contracts.Assistans
{
    public interface IAssistantProjectsService
    {
        AssistantAllProjectsViewModel GetAllProjects(int? page, string username);
    }

}
