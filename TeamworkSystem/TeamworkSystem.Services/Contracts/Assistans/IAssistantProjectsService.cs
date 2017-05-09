namespace TeamworkSystem.Services.Contracts.Assistans
{
    using TeamworkSystem.Models.ViewModels.Assistant.Projects;

    public interface IAssistantProjectsService
    {
        AssistantAllProjectsViewModel GetAllProjects(int? page, string username);
    }
}
