using System;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Projects
{
    public class ProjectInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ProjectPicture { get; set; }

        public int TeamId { get; set; }

        public string TeamName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}")]
        public DateTime PublishDate { get; set; }

        public string Description { get; set; }

        public string Repository { get; set; }

        public string LiveDemo { get; set; }

        public int CommentsCount { get; set; }

        public bool IsActive { get; set; }

    }
}
