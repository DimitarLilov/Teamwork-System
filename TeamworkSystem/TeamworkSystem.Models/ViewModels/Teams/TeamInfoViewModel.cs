using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class TeamInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<MemberViewModel> Members { get; set; }
    }
}
