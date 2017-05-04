using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class AddMembersViewModel
    {
        public int TeamId { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

    }
}
