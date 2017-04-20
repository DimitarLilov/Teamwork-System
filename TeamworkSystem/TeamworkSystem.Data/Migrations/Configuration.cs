using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        protected override void Seed(TeamworkSystemContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Student"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager =new RoleManager<IdentityRole>(store);
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
