using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Assistant.Courses
{
    public class AssistantAllCoursesViewModel
    {
        public IEnumerable<AssistantCourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
