﻿using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Users
{
    public class AllUsersCollaboratorsViewModel
    {
        public UserInfoViewModel User { get; set; }

        public IEnumerable<CollaborationUserViewModel> Collaborators { get; set; }

        public Pager Pager { get; set; }
    }
}