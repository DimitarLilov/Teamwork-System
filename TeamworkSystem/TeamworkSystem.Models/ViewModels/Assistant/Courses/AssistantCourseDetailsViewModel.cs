using System.Collections.Generic;
using TeamworkSystem.Models.ViewModels.Assistant.Projects;

namespace TeamworkSystem.Models.ViewModels.Assistant.Courses
{
    public class AssistantCourseDetailsViewModel
    {
        public AssistantCourseViewModel Course { get; set; }

        public IEnumerable<AssistantProjectViewModel> Projects { get; set; }

    }
}
