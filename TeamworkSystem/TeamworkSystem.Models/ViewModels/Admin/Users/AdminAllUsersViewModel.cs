using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Admin.Users
{
    public class AdminAllUsersViewModel
    {
        public IEnumerable<AdminUserViewModel> Users { get; set; }

        public Pager Pager { get; set; }

    }
}
