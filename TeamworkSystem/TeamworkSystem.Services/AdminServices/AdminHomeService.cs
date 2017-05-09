namespace TeamworkSystem.Services.AdminServices
{
    using System.Linq;

    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Models.ViewModels.Admin.Home;
    using TeamworkSystem.Services.Contracts.Admin;

    public class AdminHomeService : Service, IAdminHomeService
    {
        public AdminHomeService(ITeamworkSystemData data) : base(data)
        {
        }

        public string GetUserPhoto(string identityName)
        {
            return this.data.User.FindByPredicate(u => u.UserName == identityName).ProfilePhoto.UrlPthoto;
        }

        public AdminPanelViewModel GetAdminPanel()
        {
            AdminPanelViewModel vm = new AdminPanelViewModel()
            {
                UsersCount = this.data.User.GetAll().Count(),
                ProjectsCount = this.data.Projects.GetAll().Count(),
                CommentsCount = this.data.Comments.GetAll().Count(),
                CourseCount = this.data.Courses.GetAll().Count(),
                TasksCount = this.data.TeamTasks.GetAll().Count(),
                TeamsCount = this.data.Teams.GetAll().Count()
            };
            return vm;
        }
    }
}
