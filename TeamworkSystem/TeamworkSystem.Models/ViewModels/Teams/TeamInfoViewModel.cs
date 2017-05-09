namespace TeamworkSystem.Models.ViewModels.Teams
{
    using System.Collections.Generic;

    public class TeamInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<MemberViewModel> Members { get; set; }
    }
}
