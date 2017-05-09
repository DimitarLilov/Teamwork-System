namespace TeamworkSystem.Services.Contracts.Admin
{
    using TeamworkSystem.Models.ViewModels.Admin.Home;

    public interface IAdminHomeService
    {
        string GetUserPhoto(string identityName);

        AdminPanelViewModel GetAdminPanel();
    }
}
