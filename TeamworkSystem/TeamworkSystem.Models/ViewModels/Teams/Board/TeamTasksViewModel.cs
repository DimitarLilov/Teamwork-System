using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    public class TeamTasksViewModel
    {
        public int TeamId { get; set; }

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
