using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Teams
{
    public class AddMemberBindingModel
    {
        [Required]
        public string Username { get; set; }
    }
}
