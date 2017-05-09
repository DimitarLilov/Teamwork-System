namespace TeamworkSystem.Models.ViewModels.Trainer.Courses
{
    using System.Collections.Generic;

    public class TrainerCourseCriteriaViewModel
    {
        public TrainerCourseViewModel Course { get; set; }

        public IEnumerable<TrainerCriteriaViewModel> Criteria { get; set; }

        public string Name { get; set; }
    }
}
