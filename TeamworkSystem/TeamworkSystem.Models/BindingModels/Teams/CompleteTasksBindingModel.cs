using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Teams
{
    public class CompleteTasksBindingModel
    {
        [Required]
        public IEnumerable<int> TasksId { get; set; }
    }
}
