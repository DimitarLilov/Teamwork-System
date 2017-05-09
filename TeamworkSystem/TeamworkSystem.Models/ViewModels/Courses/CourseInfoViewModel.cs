namespace TeamworkSystem.Models.ViewModels.Courses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TeamworkSystem.Models.ViewModels.Projects;

    public class CourseInfoViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CoursePhoto { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

        public string TrainerUsername { get; set; }

        public string TrainerFullName { get; set; }

        public int ProjectCount { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public Pager Pager { get; set; }
    }
}
