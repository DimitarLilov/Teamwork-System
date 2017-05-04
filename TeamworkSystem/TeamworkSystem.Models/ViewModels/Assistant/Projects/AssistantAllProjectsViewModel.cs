using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Assistant.Projects
{
    public class AssistantAllProjectsViewModel
    {
        public IEnumerable<AssistantProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }

    }
}
