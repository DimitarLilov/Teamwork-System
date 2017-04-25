using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Users
{
    public class AllUsersTeamsViewModel
    {
        public UserInfoViewModel User { get; set; }

        public IEnumerable<TeamUserViewModel> Teams { get; set; }

        public Pager Pager { get; set; }

    }
}
