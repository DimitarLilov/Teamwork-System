using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Admin.Users;

namespace TeamworkSystem.Services.AdminServices
{
    public class AdminUsersService : Service
    {
        public AdminUsersService(ITeamworkSystemData data) : base(data)
        {
        }


        public AdminAllUsersViewModel GetAllUsers(int? page)
        {
            var users = this.data.User.GetAll();


            AdminAllUsersViewModel vm = new AdminAllUsersViewModel();
            vm.Users = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<AdminUserViewModel>>(users);


            var usersPage = vm.Users;
            var pager = new Pager(users.Count(), page);

            vm.Users = usersPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }

    }
}
