using System.Collections.Generic;
using TeamworkSystem.Models.ViewModels.Projects;

namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    public class BoardProjectsViewModel
    {
        public int TeamId { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }
    }
}
