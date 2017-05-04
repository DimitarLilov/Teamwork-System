using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Trainer.Courses
{
    public class TrainerCriteriaBindingModel
    {
        [Required]

        public string Name { get; set; }
    }
}
