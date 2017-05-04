using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Admin.Courses
{
    public class AdminAllCoursesViewModel
    {
        public IEnumerable<AdminCourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
