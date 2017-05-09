namespace TeamworkSystem.Models.ViewModels.Users
{
    using System.Collections.Generic;

    public class AllUsersCollaboratorsViewModel
    {
        public string Username { get; set; }

        public IEnumerable<CollaborationUserViewModel> Collaborators { get; set; }

        public Pager Pager { get; set; }
    }
}
