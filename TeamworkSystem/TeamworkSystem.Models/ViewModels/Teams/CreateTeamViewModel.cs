using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class CreateTeamViewModel
    {
        [Display(Name = "Team Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
