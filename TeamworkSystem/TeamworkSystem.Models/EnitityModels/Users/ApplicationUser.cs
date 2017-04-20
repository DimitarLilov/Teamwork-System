using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Models.Enums;

namespace TeamworkSystem.Models.EnitityModels.Users
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Skills = new HashSet<Skill>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Photo ProfilePhoto { get; set; }

        public string WebSite { get; set; }

        public string AbautMe { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public virtual Gender Gender { get; set; }

        public DateTime BirthBay { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public string SoftUniProfile { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string GooglePlus { get; set; }

        public string LinkedIn { get; set; }

        public string GitHub { get; set; }

        public string StackOverflow { get; set; }

        public string Instagram { get; set; }

        public string Skype { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
