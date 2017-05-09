using System.Collections.Generic;
using TeamworkSystem.Models.BindingModels.Users;
using TeamworkSystem.Models.ViewModels.Users;

namespace TeamworkSystem.Services.Contracts
{
    public interface IUsersService
    {
        ProfileViewModel GetUserProfile(string username);

        EditUserViewModel GetEditUser(string username);

        AllUsersProjectsViewModel GetAllUsersPublicProjects(string username);

        AllUsersTeamsViewModel GetAllUsersTeams(string username, int? page);

        AllUsersCollaboratorsViewModel GetAllUsersCollaborators(string username);

        bool ContainsUser(string username);

        UserInfoViewModel GetUserInfo(string username);

        void EditUser(string username, EditUserBindingModel binding);

        void AddImage(string pic, string username);

        IEnumerable<string> GettUsernames();
    }
}
