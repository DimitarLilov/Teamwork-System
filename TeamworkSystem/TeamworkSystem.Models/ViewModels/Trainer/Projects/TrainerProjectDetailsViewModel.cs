using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Trainer.Projects
{
    public class TrainerProjectDetailsViewModel
    {
        public TrainerProjectViewModel Project { get; set; }

        public IEnumerable<TrainerProjectAssistentsCriteriaViewModel> AsistentsCriteria { get; set; }

        public IEnumerable<TrainerProjectCriteriaViewModel> TrainerCriteria { get; set; }

    }
}
