using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakeCriteriaRepository : Repository<Criteria>
    {
        public FakeCriteriaRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeCriteriaDbSet();
        }
    }
}
