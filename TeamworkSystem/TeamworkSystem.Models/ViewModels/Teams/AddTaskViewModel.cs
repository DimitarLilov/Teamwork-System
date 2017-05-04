using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class AddTaskViewModel
    {
        public int TeamId { get; set; }

        public string Author { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now.Date;

        [Required]
        public IEnumerable<SelectMemberViewModel> Members { get; set; }
    }
}
