namespace TeamworkSystem.Models.ViewModels.Admin.Projects
{
    using System.Collections.Generic;

    public class AdminAllProjectsViewModel
    {
        public IEnumerable<AdminProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
