﻿namespace TeamworkSystem.Services.AssistantServices
{
    using AutoMapper;

    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Models.EnitityModels.Users;
    using TeamworkSystem.Models.ViewModels.Assistant.Home;
    using TeamworkSystem.Services.Contracts.Assistans;

    public class AssistantHomeService : Service, IAssistantHomeService
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
