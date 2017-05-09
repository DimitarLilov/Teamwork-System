namespace TeamworkSystem.Models.ViewModels.Trainer.Courses
{
    using System.Collections.Generic;

    public class TrainerAllCourseViewModel
    {
        public IEnumerable<TrainerCourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
