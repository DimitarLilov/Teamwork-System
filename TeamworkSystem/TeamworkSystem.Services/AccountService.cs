using TeamworkSystem.Data;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Services
{
    public class AccountService : Service
    {
        public AccountService(ITeamworkSystemData data) : base(data)
        {
        }

        public void CreateStudent(string userId)
        {
            Student student = new Student();
            student.IdenityUserId = userId;
            data.Students.Insert(student);
            data.SaveChanges();
        }
    }
}
