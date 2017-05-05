using System;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Projects
{
    public class CommentViewModel
    {
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime PostedDate { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string UserPhoto { get; set; }
    }
}
