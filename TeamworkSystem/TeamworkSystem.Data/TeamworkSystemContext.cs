using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data
{
    public class TeamworkSystemContext : IdentityDbContext<ApplicationUser>
    {
        public TeamworkSystemContext()
            : base("TeamworkSystemContext", throwIfV1Schema: false)
        {
        }

        public static TeamworkSystemContext Create()
        {
            return new TeamworkSystemContext();
        }
    }
}