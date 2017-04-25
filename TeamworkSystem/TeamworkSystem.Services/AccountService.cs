using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Services.Contracts;

namespace TeamworkSystem.Services
{
    public class AccountService : Service, IAccountService
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
