namespace TeamworkSystem.Models.ViewModels.Admin.Users
{
    using System.Collections.Generic;

    public class AdminAllUsersViewModel
    {
        public IEnumerable<AdminUserViewModel> Users { get; set; }

        public Pager Pager { get; set; }
    }
}
