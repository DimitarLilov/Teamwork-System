using System;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.BindingModels.Users
{
    public class EditUserBindingModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Url]
        public string WebSite { get; set; }

        [Url]
        public string SoftuniProfile { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Abouth Me")]
        public string AboutMe { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Url]
        public string Facebook { get; set; }

        [Url]
        public string Twitter { get; set; }

        [Url]
        public string GooglePlus { get; set; }

        [Url]
        public string LinkedIn { get; set; }

        [Url]
        public string GitHub { get; set; }

        [Url]
        public string StackOverflow { get; set; }

        [Url]
        public string Instagram { get; set; }

        public string Skype { get; set; }
    }
}
