using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakeProjectPointRepository : Repository<ProjectPoint>
    {
        public FakeProjectPointRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeProjectPointDbSet();
        }
    }
}
