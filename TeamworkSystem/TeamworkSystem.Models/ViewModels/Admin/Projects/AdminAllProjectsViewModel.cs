using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Admin.Projects
{
    public class AdminAllProjectsViewModel
    {
        public IEnumerable<AdminProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
