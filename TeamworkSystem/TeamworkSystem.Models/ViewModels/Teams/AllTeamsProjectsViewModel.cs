namespace TeamworkSystem.Models.ViewModels.Teams
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.ViewModels.Projects;

    public class AllTeamsProjectsViewModel
    {
        public int Id { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
