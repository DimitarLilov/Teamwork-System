namespace TeamworkSystem.Models.ViewModels.Teams
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.ViewModels.Courses;

    public class AllTeamsCoursesViewModel
    {
        public int Id { get; set; }

        public IEnumerable<CourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
