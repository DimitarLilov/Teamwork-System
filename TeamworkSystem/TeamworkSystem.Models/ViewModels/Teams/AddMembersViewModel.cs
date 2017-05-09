namespace TeamworkSystem.Models.ViewModels.Teams
{
    using System.ComponentModel.DataAnnotations;

    public class AddMembersViewModel
    {
        public int TeamId { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

    }
}
