using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Projects
{
    public class CommentBindingModel
    {
        [Required]
        public string Content { get; set; }
    }
}
