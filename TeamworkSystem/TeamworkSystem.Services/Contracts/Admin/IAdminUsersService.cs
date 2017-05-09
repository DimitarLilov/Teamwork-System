namespace TeamworkSystem.Services.Contracts.Admin
{
    using TeamworkSystem.Models.ViewModels.Admin.Users;

    public interface IAdminUsersService
    {
        AdminAllUsersViewModel GetAllUsers(int? page);
    }
}
