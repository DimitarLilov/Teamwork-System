using TeamworkSystem.Models.ViewModels.Admin.Users;

namespace TeamworkSystem.Services.Contracts.Admin
{
    public interface IAdminUsersService
    {
        AdminAllUsersViewModel GetAllUsers(int? page);
    }

}
