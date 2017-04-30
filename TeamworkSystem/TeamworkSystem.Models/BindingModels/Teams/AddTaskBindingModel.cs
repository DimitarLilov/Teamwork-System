using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Teams
{
    public class AddTaskBindingModel
    {
        public string Author { get; set; }

        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public IEnumerable<string> Username { get; set; }
    }
}
