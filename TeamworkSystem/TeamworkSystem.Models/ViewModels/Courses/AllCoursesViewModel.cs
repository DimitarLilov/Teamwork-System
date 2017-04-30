using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Courses
{
    public class AllCoursesViewModel
    {
        public IEnumerable<CourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
