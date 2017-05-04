using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Services.Contracts;
using TeamworkSystem.Utillities.Constants;

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

        public void SetProfileImage(string userId)
        {
            Photo photo = this.data.Photos.FindByPredicate(p => p.UrlPthoto == PathConstants.UnknownAvatar);
            this.data.User.FindByPredicate(u => u.Id == userId).ProfilePhoto = photo;
            data.SaveChanges();
        }
    }
}
