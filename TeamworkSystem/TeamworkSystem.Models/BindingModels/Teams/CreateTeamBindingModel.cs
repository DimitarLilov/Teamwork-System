namespace TeamworkSystem.Models.BindingModels.Teams
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTeamBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
