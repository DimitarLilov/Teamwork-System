namespace TeamworkSystem.Models.ViewModels.Assistant.Projects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AssistantProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TeamName { get; set; }

        public string CourseName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMMM/dd/yyyy}")]
        public DateTime PublishDate { get; set; }

        public bool IsPublic { get; set; }
    }
}
