namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public IEnumerable<MemberViewModel> Members { get; set; }
    }
}
