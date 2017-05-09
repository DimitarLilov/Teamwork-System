namespace TeamworkSystem.Data.Moks.Repositories
{
    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Data.Moks.DbSet;
    using TeamworkSystem.Data.Repositories;
    using TeamworkSystem.Models.EnitityModels;

    public class FakePointRepository : Repository<Point>
    {
        public FakePointRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakePointDbSet();
        }
    }
}
