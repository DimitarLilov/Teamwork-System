namespace TeamworkSystem.Data.Moks.DbSet
{
    using System.Linq;

    using TeamworkSystem.Models.EnitityModels;

    public class FakeCourseDbSet : FakeDbSet<Course>
    {
        public override Course Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
