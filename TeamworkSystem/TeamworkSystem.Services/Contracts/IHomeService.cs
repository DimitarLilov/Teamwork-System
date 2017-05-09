namespace TeamworkSystem.Services.Contracts
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.ViewModels.Home;

    public interface IHomeService
    {
        string GetUserPhoto(string identityName);

        IEnumerable<TopProjectsViewModel> GetTopProjects();
    }
}
