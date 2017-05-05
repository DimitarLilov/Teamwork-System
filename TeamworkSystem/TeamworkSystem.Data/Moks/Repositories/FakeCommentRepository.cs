using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakeCommentRepository : Repository<Comment>
    {
        public FakeCommentRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeCommentDbSet();
        }
    }
}
