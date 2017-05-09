namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.ViewModels.Projects;

    public class BoardProjectsViewModel
    {
        public int TeamId { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}
