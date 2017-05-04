using System;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Assistant.Courses
{
    public class AssistantCourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

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
