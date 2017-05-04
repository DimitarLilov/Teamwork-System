using System;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Trainer.Projects
{
    public class TrainerProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Course")]
        public string CourseName { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Public")]
        public bool IsPublic { get; set; }

        public int Vote { get; set; }

        public decimal Grade { get; set; }
    }
}
