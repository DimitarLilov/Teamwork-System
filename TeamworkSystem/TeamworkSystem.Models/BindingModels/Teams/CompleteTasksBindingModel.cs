namespace TeamworkSystem.Models.BindingModels.Teams
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CompleteTasksBindingModel
    {
        [Required]
        public IEnumerable<int> TasksId { get; set; }
    }
}
