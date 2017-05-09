namespace TeamworkSystem.Models.ViewModels.Admin.Courses
{
    using System.Collections.Generic;

    public class AdminAllCoursesViewModel
    {
        public IEnumerable<AdminCourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
