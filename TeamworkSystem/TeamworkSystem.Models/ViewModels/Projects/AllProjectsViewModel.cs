using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Projects
{
    public class AllProjectsViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
