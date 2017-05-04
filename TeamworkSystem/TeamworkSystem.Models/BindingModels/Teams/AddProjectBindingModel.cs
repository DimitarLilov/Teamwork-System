using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Teams
{
    public class AddProjectBindingModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Url]
        public string Repository { get; set; }

        [Url]
        public string LiveDemo { get; set; }

        public bool IsPublic { get; set; }
    }
}
