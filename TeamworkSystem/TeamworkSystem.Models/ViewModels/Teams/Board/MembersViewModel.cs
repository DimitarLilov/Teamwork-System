namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    using System.Collections.Generic;

    public class MembersViewModel
    {
        public int TeamId { get; set; }

        public IEnumerable<BoardMemberViewModel> Members { get; set; }
    }
}
