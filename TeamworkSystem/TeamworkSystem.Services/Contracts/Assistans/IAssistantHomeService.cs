using TeamworkSystem.Models.ViewModels.Assistant.Home;

namespace TeamworkSystem.Services.Contracts.Assistans
{
    public interface IAssistantHomeService
    {
        AssistantPanelViewModel GetAssistantInfo(string username);
    }

}
