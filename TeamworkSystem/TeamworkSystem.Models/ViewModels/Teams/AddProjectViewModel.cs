namespace TeamworkSystem.Models.ViewModels.Teams
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TeamworkSystem.Models.ViewModels.Projects;

    public class AddProjectViewModel
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }

        [Display(Name = "Course")]
        public IEnumerable<ProjectCoursesViewModel> Course { get; set; }

        public string Repository { get; set; }

        public string LiveDemo { get; set; }

        [Display(Name = "Public")]
        public bool IsPublic { get; set; }
    }
}
