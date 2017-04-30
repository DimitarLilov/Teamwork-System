using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamworkSystem.Models.ViewModels.Courses;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class DashboardInfoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Team Name")]
        public string Name { get; set; }

        [Display(Name = "Project Count")]
        public int ProjectsCount { get; set; }

        [Display(Name = "Members")]
        public IEnumerable<MemberViewModel> Members { get; set; }
    }
}
