using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class TeamViewModel
    {
        public TeamInfoViewModel Team { get; set; }

        public IEnumerable<ProjectTeamViewModel> Projects { get; set; }

        public IEnumerable<CourseTeamViewModel> Courses { get; set; }
    }
}
