namespace TeamworkSystem.Models.ViewModels.Users
{
    using System.Collections.Generic;

    public class AllUsersTeamsViewModel
    {
        public string Username { get; set; }

        public IEnumerable<TeamUserViewModel> Teams { get; set; }

        public Pager Pager { get; set; }

    }
}
