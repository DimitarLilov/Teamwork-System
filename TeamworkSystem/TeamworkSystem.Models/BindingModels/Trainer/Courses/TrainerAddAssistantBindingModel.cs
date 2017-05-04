using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Trainer.Courses
{
    public class TrainerAddAssistantBindingModel
    {
        [Required]
        public string Username { get; set; }
    }
}
