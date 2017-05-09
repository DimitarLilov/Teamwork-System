namespace TeamworkSystem.Models.ViewModels.Trainer.Courses
{
    using System.ComponentModel.DataAnnotations;

    public class TrainerCourseEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Max Grade")]
        public decimal MaxGrade { get; set; }
    }
}
