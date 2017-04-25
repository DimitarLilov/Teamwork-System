using System;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Users
{
    public class EditUserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string WebSite { get; set; }

        public string SoftuniProfile { get; set; }

        public string PhoneNumber { get; set; }

        public string AboutMe { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string GooglePlus { get; set; }

        public string LinkedIn { get; set; }

        public string GitHub { get; set; }

        public string StackOverflow { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }
    }
}
