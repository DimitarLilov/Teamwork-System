namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    using System.Collections.Generic;

    public class TeamTasksViewModel
    {
        public int TeamId { get; set; }

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
