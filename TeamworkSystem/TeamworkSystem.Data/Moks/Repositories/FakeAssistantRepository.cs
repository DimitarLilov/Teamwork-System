using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakeAssistantRepository : Repository<Assistent>
    {
        public FakeAssistantRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeAssistantDbSet();
        }
    }
}
