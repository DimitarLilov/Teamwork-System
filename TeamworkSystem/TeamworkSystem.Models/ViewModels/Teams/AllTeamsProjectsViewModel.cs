using System.Collections.Generic;
using TeamworkSystem.Models.ViewModels.Projects;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class AllTeamsProjectsViewModel
    {
        public TeamInfoViewModel Team { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }

    }
}
