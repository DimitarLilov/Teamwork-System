using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamworkSystem.Models.ViewModels.Users
{
    public class ProfileViewModel
    {
        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string ProfilePhoto { get; set; }

        [DisplayFormat(NullDisplayText = "Web Site")]
        public string WebSite { get; set; }

        public string SoftuniProfile { get; set; }

        [DisplayFormat(NullDisplayText = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayFormat(NullDisplayText = "About Me")]
        public string AboutMe { get; set; }

        [DisplayFormat(NullDisplayText = "Country")]
        public string Country { get; set; }

        [DisplayFormat(NullDisplayText = "Town")]
        public string Town { get; set; }

        public string Gender { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string GooglePlus { get; set; }

        public string LinkedIn { get; set; }

        public string GitHub { get; set; }

        public string StackOverflow { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }

        public IEnumerable<string> Skills { get; set; }

        public IEnumerable<ProjectUsersViewModel> Projects { get; set; }

        public IEnumerable<TeamUserViewModel> Teams { get; set; }

        public IEnumerable<CollaborationUserViewModel> Collaborators { get; set; }

    }
}
