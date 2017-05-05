using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakeMessageRepository : Repository<Message>
    {
        public FakeMessageRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeMessageDbSet();
        }
    }
}
