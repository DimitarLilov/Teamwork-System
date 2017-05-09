namespace TeamworkSystem.Models.ViewModels.Assistant.Projects
{
    using System.Collections.Generic;

    public class AssistantAllProjectsViewModel
    {
        public IEnumerable<AssistantProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
