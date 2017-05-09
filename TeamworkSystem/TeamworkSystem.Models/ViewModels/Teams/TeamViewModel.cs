namespace TeamworkSystem.Models.ViewModels.Teams
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.ViewModels.Courses;
    using TeamworkSystem.Models.ViewModels.Projects;

    public class TeamViewModel
    {
        public int Id { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}
