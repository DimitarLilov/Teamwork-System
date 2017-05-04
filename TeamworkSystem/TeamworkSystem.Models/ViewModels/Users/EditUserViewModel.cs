using System;
using System.ComponentModel.DataAnnotations;
using TeamworkSystem.Models.Enums;

namespace TeamworkSystem.Models.ViewModels.Users
{
    public class EditUserViewModel
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string ProfilePicturePath { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Url]
        [Display(Name = "Web Site")]
        public string WebSite { get; set; }

        [Url]
        [Display(Name = "SoftUni Profile")]
        public string SoftuniProfile { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Abouth Me")]
        public string AboutMe { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Url]
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [Url]
        [Display(Name = "Twitter")]
        public string Twitter { get; set; }

        [Url]
        [Display(Name = "Google Plus")]
        public string GooglePlus { get; set; }
        
        [Url]
        [Display(Name = "LinkedIn")]
        public string LinkedIn { get; set; }

        [Url]
        [Display(Name = "GitHub")]
        public string GitHub { get; set; }

        [Url]
        [Display(Name = "Stack Overflow")]
        public string StackOverflow { get; set; }

        [Url]
        [Display(Name = "Instagram")]
        public string Instagram { get; set; }

        public string Skype { get; set; }
    }
}
