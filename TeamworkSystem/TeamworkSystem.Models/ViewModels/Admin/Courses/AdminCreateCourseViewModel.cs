using System;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Admin.Courses
{
    public class AdminCreateCourseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Trainer")]
        public string TrainerUsername { get; set; }

        [Display(Name = "Max Grade")]
        public decimal MaxGrade { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
    }
}
