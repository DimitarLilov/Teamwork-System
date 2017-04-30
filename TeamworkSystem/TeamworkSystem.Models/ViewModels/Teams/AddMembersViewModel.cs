using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class AddMembersViewModel
    {
        [Display(Name = "Team")]
        public TeamInfoViewModel Team { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

    }
}
