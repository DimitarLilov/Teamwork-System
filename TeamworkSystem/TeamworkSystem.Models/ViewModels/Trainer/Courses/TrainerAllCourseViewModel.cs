using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Trainer.Courses
{
    public class TrainerAllCourseViewModel
    {
        public IEnumerable<TrainerCourseViewModel> Courses { get; set; }

        public Pager Pager { get; set; }
    }
}
