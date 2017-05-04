using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Assistant.Home;

namespace TeamworkSystem.Services.AssistantServices
{
    public class AssistantHomeService:Service
    {
        public AssistantHomeService(ITeamworkSystemData data) : base(data)
        {
        }

        public AssistantPanelViewModel GetAssistantInfo(string username)
        {
            var assistant = this.data.Assistents.FindByPredicate(a => a.IdentityUser.UserName == username);

            return Mapper.Map<Assistent, AssistantPanelViewModel>(assistant);
        }

    }
}
