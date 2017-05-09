namespace TeamworkSystem.Data.Moks.Repositories
{
    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Data.Moks.DbSet;
    using TeamworkSystem.Data.Repositories;
    using TeamworkSystem.Models.EnitityModels;

    public class FakeCriteriaRepository : Repository<Criteria>
    {
        public FakeCriteriaRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeCriteriaDbSet();
        }
    }
}
