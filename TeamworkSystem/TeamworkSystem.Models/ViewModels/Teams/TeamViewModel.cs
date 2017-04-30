using System.Collections.Generic;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class TeamViewModel
    {
        public TeamInfoViewModel Team { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
