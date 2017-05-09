namespace TeamworkSystem.Models.BindingModels.Trainer.Courses
{
    using System.ComponentModel.DataAnnotations;

    public class TrainerCourseEditBindingModel
    {
        public string Description { get; set; }

        [Display(Name = "Max Grade")]
        public decimal MaxGrade { get; set; }
    }
}
