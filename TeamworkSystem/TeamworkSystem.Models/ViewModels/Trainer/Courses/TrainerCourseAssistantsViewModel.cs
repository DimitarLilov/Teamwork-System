namespace TeamworkSystem.Models.ViewModels.Trainer.Courses
{
    using System.Collections.Generic;

    public class TrainerCourseAssistantsViewModel
    {
        public TrainerCourseViewModel Course { get; set; }

        public IEnumerable<TrainerCourseAssistantViewModel> Assistants { get; set; }

        public string Username { get; set; }
    }
}
