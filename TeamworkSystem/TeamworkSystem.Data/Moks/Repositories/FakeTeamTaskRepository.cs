using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakeTeamTaskRepository : Repository<TeamTask>
    {
        public FakeTeamTaskRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeTeamTaskDbSet();
        }
    }
}
