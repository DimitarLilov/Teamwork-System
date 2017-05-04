using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Trainer.Courses
{
    public class TrainerCourseAssistantsViewModel
    {
        public TrainerCourseViewModel Course { get; set; }

        public IEnumerable<TrainerCourseAssistantViewModel> Assistants { get; set; }

        public string Username { get; set; }
    }
}
