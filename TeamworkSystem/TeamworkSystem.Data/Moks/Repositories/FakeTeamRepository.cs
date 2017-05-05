using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakeTeamRepository : Repository<Team>
    {
        public FakeTeamRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeTeamDbSet();
        }
    }
}
