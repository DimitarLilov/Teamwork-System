namespace TeamworkSystem.Models.BindingModels.Trainer.Courses
{
    using System.ComponentModel.DataAnnotations;

    public class TrainerCriteriaBindingModel
    {
        [Required]

        public string Name { get; set; }
    }
}
