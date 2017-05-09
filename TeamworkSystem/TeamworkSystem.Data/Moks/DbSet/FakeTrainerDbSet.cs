namespace TeamworkSystem.Data.Moks.DbSet
{
    using System.Linq;

    using TeamworkSystem.Models.EnitityModels.Users;

    public class FakeTrainerDbSet : FakeDbSet<Trainer>
    {
        public override Trainer Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
