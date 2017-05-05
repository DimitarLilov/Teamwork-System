using System.Linq;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Moks.DbSet
{
    public class FakeMessageDbSet : FakeDbSet<Message>
    {
        public override Message Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }

    }
}
