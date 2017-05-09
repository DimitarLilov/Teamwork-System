namespace TeamworkSystem.Models.BindingModels.Admin.Courses
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminEditCourseBindingModel
    {
        public string Description { get; set; }

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
