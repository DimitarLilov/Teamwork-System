using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Moks.DbSet;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data.Moks.Repositories
{
    public class FakeStudentRepository : Repository<Student>
    {
        public FakeStudentRepository(ITeamworkSystemContext context) : base(context)
        {
            this.EntityTable = new FakeStudentDbSet();
        }
    }
}
