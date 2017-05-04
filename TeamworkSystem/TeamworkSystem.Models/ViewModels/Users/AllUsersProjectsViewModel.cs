using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Users
{
    public class AllUsersProjectsViewModel
    {
        public string Username { get; set; }

        public IEnumerable<ProjectUsersViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
