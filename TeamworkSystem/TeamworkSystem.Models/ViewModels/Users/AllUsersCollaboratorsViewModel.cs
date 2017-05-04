using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Users
{
    public class AllUsersCollaboratorsViewModel
    {
        public string Username { get; set; }

        public IEnumerable<CollaborationUserViewModel> Collaborators { get; set; }

        public Pager Pager { get; set; }
    }
}
