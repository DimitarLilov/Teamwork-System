namespace TeamworkSystem.Data.Moks.DbSet
{
    using System.Linq;

    using TeamworkSystem.Models.EnitityModels.Users;

    public class FakeApplicationUserDbSet : FakeDbSet<ApplicationUser>
    {
        public override ApplicationUser Find(params object[] keyValues)
        {
            string wantedId = (string)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
