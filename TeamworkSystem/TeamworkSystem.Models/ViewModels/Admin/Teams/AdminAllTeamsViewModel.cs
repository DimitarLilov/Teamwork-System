namespace TeamworkSystem.Models.ViewModels.Admin.Teams
{
    using System.Collections.Generic;

    public class AdminAllTeamsViewModel
    {
        public IEnumerable<AdminTeamViewModel> Teams { get; set; }

        public Pager Pager { get; set; }
    }
}
