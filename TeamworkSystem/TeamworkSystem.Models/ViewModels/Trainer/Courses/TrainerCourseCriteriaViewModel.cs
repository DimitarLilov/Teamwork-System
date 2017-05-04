using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Trainer.Courses
{
    public class TrainerCourseCriteriaViewModel
    {
        public TrainerCourseViewModel Course { get; set; }

        public IEnumerable<TrainerCriteriaViewModel> Criteria { get; set; }

        public string Name { get; set; }
    }
}
