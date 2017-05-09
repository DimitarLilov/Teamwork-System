namespace TeamworkSystem.Data.Moks.Repositories
{
    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Data.Moks.DbSet;
    using TeamworkSystem.Data.Repositories;
    using TeamworkSystem.Models.EnitityModels;

    public class FakeTeamTaskRepository : Repository<TeamTask>
    {
        public FakeTeamTaskRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeTeamTaskDbSet();
        }
    }
}
