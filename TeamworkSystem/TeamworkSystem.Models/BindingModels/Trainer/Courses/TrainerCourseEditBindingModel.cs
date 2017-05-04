using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Trainer.Courses
{
    public class TrainerCourseEditBindingModel
    {
        public string Description { get; set; }

        [Display(Name = "Max Grade")]
        public decimal MaxGrade { get; set; }
    }
}
