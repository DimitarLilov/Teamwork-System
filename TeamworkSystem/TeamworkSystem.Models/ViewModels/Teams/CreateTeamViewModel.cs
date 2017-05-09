namespace TeamworkSystem.Models.ViewModels.Teams
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTeamViewModel
    {
        [Display(Name = "Team Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
