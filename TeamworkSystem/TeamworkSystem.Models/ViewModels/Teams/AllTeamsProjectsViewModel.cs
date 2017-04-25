using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class AllTeamsProjectsViewModel
    {
        public TeamInfoViewModel Team { get; set; }

        public IEnumerable<ProjectTeamViewModel> Projects { get; set; }

        public Pager Pager { get; set; }

    }
}
