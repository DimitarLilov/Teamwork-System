using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Teams.Board
{
    public class BoardViewModel
    {
        public int TeamId { get; set; }

        [Display(Name = "Tasks")]
        public IEnumerable<TaskViewModel> ComplateTasks { get; set; }

        [Display(Name = "My Task")]
        public IEnumerable<MyTaskViewModel> MyTasks { get; set; }
    }
}
