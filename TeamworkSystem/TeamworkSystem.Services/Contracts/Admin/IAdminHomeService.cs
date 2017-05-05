using TeamworkSystem.Models.ViewModels.Admin.Home;

namespace TeamworkSystem.Services.Contracts.Admin
{
    public interface IAdminHomeService
    {
        string GetUserPhoto(string identityName);
        AdminPanelViewModel GetAdminPanel();
    }
}
