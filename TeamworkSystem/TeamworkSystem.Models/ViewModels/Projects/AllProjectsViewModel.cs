namespace TeamworkSystem.Models.ViewModels.Projects
{
    using System.Collections.Generic;

    public class AllProjectsViewModel
    {
        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
