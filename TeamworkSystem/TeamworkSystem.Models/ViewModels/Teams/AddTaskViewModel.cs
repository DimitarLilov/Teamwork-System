namespace TeamworkSystem.Models.ViewModels.Teams
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AddTaskViewModel
    {
        public int TeamId { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now.Date;

        public IEnumerable<SelectMemberViewModel> Members { get; set; }
    }
}
