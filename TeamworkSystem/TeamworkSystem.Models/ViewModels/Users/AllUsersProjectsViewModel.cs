namespace TeamworkSystem.Models.ViewModels.Users
{
    using System.Collections.Generic;

    public class AllUsersProjectsViewModel
    {
        public string Username { get; set; }

        public IEnumerable<ProjectUsersViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
