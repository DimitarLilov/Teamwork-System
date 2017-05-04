using System;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Admin.Courses
{
    public class AdminCreateCourseBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Trainer")]
        public string TrainerUsername { get; set; }

        [Display(Name = "Max Grade")]
        public decimal MaxGrade { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
    }
}
