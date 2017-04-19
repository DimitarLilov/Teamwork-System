using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Data.Interfaces;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data
{
    public class TeamworkSystemContext : IdentityDbContext<ApplicationUser>, ITeamworkSystemContext
    {
        public TeamworkSystemContext()
            : base("TeamworkSystemContext", throwIfV1Schema: false)
        {
        }

        public static TeamworkSystemContext Create()
        {
            return new TeamworkSystemContext();
        }

        public IDbSet<Project> Projects { get; set; }
        public IdentityDbContext DbContext { get; set; }
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}