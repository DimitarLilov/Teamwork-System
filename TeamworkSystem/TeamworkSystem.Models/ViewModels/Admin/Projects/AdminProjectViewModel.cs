namespace TeamworkSystem.Models.ViewModels.Admin.Projects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Course { get; set; }

        public string Team { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsPublic { get; set; }

        public int Vote { get; set; }

        public decimal Grade { get; set; }
    }
}
