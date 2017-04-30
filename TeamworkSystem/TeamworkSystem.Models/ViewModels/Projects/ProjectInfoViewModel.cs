using System.Collections.Generic;
using TeamworkSystem.Models.ViewModels.Courses;

namespace TeamworkSystem.Models.ViewModels.Projects
{
    public class ProjectInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProjectPicture { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        public string Description { get; set; }

        public string Repository { get; set; }

        public string LiveDemo { get; set; }

        public int CommentsCount { get; set; }

    }
}
