namespace TeamworkSystem.Models.EnitityModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using TeamworkSystem.Models.Enums;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Skills = new HashSet<Skill>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => this.FirstName + " " + this.LastName;

        public virtual Photo ProfilePhoto { get; set; }

        public string WebSite { get; set; }

        public string AboutMe { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public virtual Gender Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

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
