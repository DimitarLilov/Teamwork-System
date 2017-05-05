using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakePhotoRepository : Repository<Photo>
    {
        public FakePhotoRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakePhotoDbSet();
        }
    }
}
