using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Utillities.Constants;

namespace TeamworkSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TeamworkSystem.Data.TeamworkSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TeamworkSystem.Data.TeamworkSystemContext context)
        {
            Photo profilePhoto = new Photo
            {
                UrlPthoto = PathConstants.UnknownAvatar
            };

            context.Photos.Add(profilePhoto);

            Photo projectPhoto = new Photo
            {
                UrlPthoto = PathConstants.UnknownProject
            };

            context.Photos.Add(projectPhoto);

            Photo coursePhoto = new Photo
            {
                UrlPthoto = PathConstants.UnknownCourse
            };

            context.Photos.Add(coursePhoto);

            if (!context.Roles.Any(role => role.Name == "Student"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Student");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "Trainer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Trainer");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "Assistant"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Assistant");
                manager.Create(role);
            }
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }
        }
    }
}
