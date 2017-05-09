namespace TeamworkSystem.Models.BindingModels.Trainer.Courses
{
    using System.ComponentModel.DataAnnotations;

    public class TrainerAddAssistantBindingModel
    {
        [Required]
        public string Username { get; set; }
    }
}
