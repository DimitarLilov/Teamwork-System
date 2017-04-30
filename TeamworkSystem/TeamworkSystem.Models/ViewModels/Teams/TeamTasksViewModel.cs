using System.Collections.Generic;

namespace TeamworkSystem.Models.ViewModels.Teams
{
    public class TeamTasksViewModel
    {
        public DashboardInfoViewModel TeamInfo { get; set; }

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
