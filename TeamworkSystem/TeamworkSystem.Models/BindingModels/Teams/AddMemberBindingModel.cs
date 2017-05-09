namespace TeamworkSystem.Models.BindingModels.Teams
{
    using System.ComponentModel.DataAnnotations;

    public class AddMemberBindingModel
    {
        [Required]
        public string Username { get; set; }
    }
}
