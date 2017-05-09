namespace TeamworkSystem.Data.Moks.DbSet
{
    using System.Linq;

    using TeamworkSystem.Models.EnitityModels;

    public class FakeMessageDbSet : FakeDbSet<Message>
    {
        public override Message Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
