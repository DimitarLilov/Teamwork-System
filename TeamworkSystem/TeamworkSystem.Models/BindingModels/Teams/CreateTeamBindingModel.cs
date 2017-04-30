using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Teams
{
    public class CreateTeamBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
