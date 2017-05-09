namespace TeamworkSystem.Models.ViewModels.Trainer.Projects
{
    using System.Collections.Generic;

    public class TrainerAllProjectsViewModel
    {
        public IEnumerable<TrainerProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
