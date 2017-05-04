using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Admin.Teams
{
    public class AdminAllTeamsViewModel
    {
        public IEnumerable<AdminTeamViewModel> Teams { get; set; }

        public Pager Pager { get; set; }

    }
}
