using System.Linq;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data.Moks.DbSet
{
    public class FakeAssistantDbSet : FakeDbSet<Assistent>
    {
        public override Assistent Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
