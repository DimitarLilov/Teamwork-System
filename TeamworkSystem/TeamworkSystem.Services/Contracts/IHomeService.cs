using System.Collections.Generic;
using TeamworkSystem.Models.ViewModels.Home;

namespace TeamworkSystem.Services.Contracts
{
    public interface IHomeService
    {
        string GetUserPhoto(string identityName);
        IEnumerable<TopProjectsViewModel> GetTopProjects();
    }

}
