namespace TeamworkSystem.Data.Moks.Repositories
{
    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Data.Moks.DbSet;
    using TeamworkSystem.Data.Repositories;
    using TeamworkSystem.Models.EnitityModels;

    public class FakeMessageRepository : Repository<Message>
    {
        public FakeMessageRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeMessageDbSet();
        }
    }
}
