using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using TeamworkSystem.Models.BindingModels.Admin.Courses;
using TeamworkSystem.Models.BindingModels.Courses;
using TeamworkSystem.Models.BindingModels.Projects;
using TeamworkSystem.Models.BindingModels.Teams;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Admin.Courses;
using TeamworkSystem.Models.ViewModels.Admin.Projects;
using TeamworkSystem.Models.ViewModels.Admin.Teams;
using TeamworkSystem.Models.ViewModels.Admin.Users;
using TeamworkSystem.Models.ViewModels.Assistant.Courses;
using TeamworkSystem.Models.ViewModels.Assistant.Home;
using TeamworkSystem.Models.ViewModels.Assistant.Projects;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Home;
using TeamworkSystem.Models.ViewModels.Projects;
using TeamworkSystem.Models.ViewModels.Teams;
using TeamworkSystem.Models.ViewModels.Teams.Board;
using TeamworkSystem.Models.ViewModels.Trainer.Courses;
using TeamworkSystem.Models.ViewModels.Trainer.Home;
using TeamworkSystem.Models.ViewModels.Trainer.Projects;
using TeamworkSystem.Models.ViewModels.Users;

namespace TeamworkSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MapperConfig.ConfigureAutomapper();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        
    }
}
