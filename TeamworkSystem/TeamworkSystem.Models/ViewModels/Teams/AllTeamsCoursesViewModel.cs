using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class AllTeamsCoursesViewModel
    {
        public TeamInfoViewModel Team { get; set; }

        public IEnumerable<CourseTeamViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
