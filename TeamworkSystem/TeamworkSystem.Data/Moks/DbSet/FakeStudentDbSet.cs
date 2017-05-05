using System.Linq;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data.Moks.DbSet
{
    public class FakeStudentDbSet :FakeDbSet<Student>
    {
        public override Student Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(c => c.Id == wantedId);
        }
    }
}
