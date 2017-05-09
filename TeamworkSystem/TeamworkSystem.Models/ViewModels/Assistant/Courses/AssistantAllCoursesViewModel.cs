namespace TeamworkSystem.Models.ViewModels.Assistant.Courses
{
    using System.Collections.Generic;

    public class AssistantAllCoursesViewModel
    {
        public IEnumerable<AssistantCourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
