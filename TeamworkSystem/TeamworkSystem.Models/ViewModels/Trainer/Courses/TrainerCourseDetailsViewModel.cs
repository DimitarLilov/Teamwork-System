using System.Collections.Generic;
using TeamworkSystem.Models.ViewModels.Trainer.Projects;

namespace TeamworkSystem.Models.ViewModels.Trainer.Courses
{
    public class TrainerCourseDetailsViewModel
    {
        public TrainerCourseViewModel Course { get; set; }

        public IEnumerable<TrainerProjectViewModel> Projects { get; set; }

    }
}
