﻿namespace TeamworkSystem.Models.ViewModels.Admin.Teams
{
    using System.Collections.Generic;

    public class AdminTeamDetailsViewModel
    {
        public AdminTeamViewModel Team { get; set; }

        public string Description { get; set; }

        public IEnumerable<AdminTeamMembersViewModel> Members { get; set; }
    }
}
