namespace TeamworkSystem.Services.Contracts.Assistans
{
    using TeamworkSystem.Models.ViewModels.Assistant.Home;

    public interface IAssistantHomeService
    {
        AssistantPanelViewModel GetAssistantInfo(string username);
    }
}
