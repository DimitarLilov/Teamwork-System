using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamworkSystem.Models.ViewModels.Projects;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class AddProjectViewModel
    {
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Display(Name = "Course")]
        public IEnumerable<ProjectCoursesViewModel> Course { get; set; }

        [Url]
        public string Repository { get; set; }

        [Url]
        public string LiveDemo { get; set; }

        [Display(Name = "Public")]
        public bool IsPublic { get; set; }
    }
}
