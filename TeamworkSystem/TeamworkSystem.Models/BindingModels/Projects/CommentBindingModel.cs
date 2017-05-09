namespace TeamworkSystem.Models.BindingModels.Projects
{
    using System.ComponentModel.DataAnnotations;

    public class CommentBindingModel
    {
        [Required]
        public string Content { get; set; }
    }
}
