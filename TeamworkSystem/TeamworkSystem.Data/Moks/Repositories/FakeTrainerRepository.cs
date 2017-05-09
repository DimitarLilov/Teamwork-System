namespace TeamworkSystem.Data.Moks.Repositories
{
    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Data.Moks.DbSet;
    using TeamworkSystem.Data.Repositories;
    using TeamworkSystem.Models.EnitityModels.Users;

    public class FakeTrainerRepository : Repository<Trainer>
    {
        public FakeTrainerRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeTrainerDbSet();
        }
    }
}
