using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Users
{
    public class AllUsersProjectsViewModel
    {
        public UserInfoViewModel User { get; set; }

        public IEnumerable<ProjectUsersViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
