namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BoardInfoViewModel
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
