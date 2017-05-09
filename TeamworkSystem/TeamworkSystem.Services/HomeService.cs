namespace TeamworkSystem.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.ViewModels.Home;
    using TeamworkSystem.Services.Contracts;

    public class HomeService : Service, IHomeService
    {
        public HomeService(ITeamworkSystemData data) : base(data)
        {
        }

        public string GetUserPhoto(string identityName)
        {
            return this.data.User.FindByPredicate(u => u.UserName == identityName).ProfilePhoto.UrlPthoto;
        }

        public IEnumerable<TopProjectsViewModel> GetTopProjects()
        {
            IEnumerable<Project> projects = this.data.Projects.GetAll().OrderByDescending(p => p.Grade).Take(5);
            return Mapper.Map<IEnumerable<Project>, IEnumerable<TopProjectsViewModel>>(projects);
        }
    }
}
