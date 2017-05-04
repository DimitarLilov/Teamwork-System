using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    public class MembersViewModel
    {
        public int TeamId { get; set; }

        public IEnumerable<BoardMemberViewModel> Members { get; set; }

    }
}
