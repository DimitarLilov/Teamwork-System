namespace TeamworkSystem.Data.Moks.DbSet
{
    using System.Linq;

    using TeamworkSystem.Models.EnitityModels;

    public class FakeCriteriaDbSet : FakeDbSet<Criteria>
    {
        public override Criteria Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
