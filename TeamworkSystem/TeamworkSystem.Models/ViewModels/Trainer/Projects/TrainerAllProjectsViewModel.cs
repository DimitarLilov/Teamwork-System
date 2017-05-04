using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Trainer.Projects
{
    public class TrainerAllProjectsViewModel
    {
        public IEnumerable<TrainerProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
