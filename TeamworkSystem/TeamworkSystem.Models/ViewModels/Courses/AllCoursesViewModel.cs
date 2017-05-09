namespace TeamworkSystem.Models.ViewModels.Courses
{
    using System.Collections.Generic;

    public class AllCoursesViewModel
    {
        public IEnumerable<CourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
