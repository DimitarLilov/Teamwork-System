using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Projects
{
    public class EditProjectBindingModel
    {
        public string Description { get; set; }

        [Url]
        public string Repository { get; set; }

        [Url]
        public string LiveDemo { get; set; }

        public bool IsPublic { get; set; }
    }
}
