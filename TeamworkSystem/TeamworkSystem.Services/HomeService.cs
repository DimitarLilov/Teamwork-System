using System.Collections.Generic;
using System.Linq;
using TeamworkSystem.Data.Contracts;

namespace TeamworkSystem.Services
{
    public class HomeService : Service
    {
        public HomeService(ITeamworkSystemData data) : base(data)
        {
        }


        public string GetUserPhoto(string identityName)
        {
            return this.data.User.FindByPredicate(u => u.UserName == identityName).ProfilePhoto.UrlPthoto;
        }
    }
}
