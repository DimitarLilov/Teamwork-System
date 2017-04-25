using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Teams;
using TeamworkSystem.Models.ViewModels.Users;

namespace TeamworkSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
                {
                    expression.CreateMap<Team, TeamUserViewModel>()
                        .ForMember(vm => vm.CountMembers,
                            configutionExpression => configutionExpression.MapFrom(t => t.Members.Count));

                    expression.CreateMap<Project, ProjectUsersViewModel>()
                        .ForMember(vm => vm.PhotoPath,
                            configutionExpression => configutionExpression.MapFrom(p => p.ProjectPicture.UrlPthoto));

                    expression.CreateMap<ApplicationUser, ProfileViewModel>()
                        .ForMember(vm => vm.Skills,
                            configutionExpression =>
                                configutionExpression.MapFrom(u => u.Skills.Select(s => s.SkillName)))
                        .ForMember(vm => vm.ProfilePhoto,
                            configutionExpression => configutionExpression.MapFrom(p => p.ProfilePhoto.UrlPthoto));

                    expression.CreateMap<Student, CollaborationUserViewModel>()
                        .ForMember(vm => vm.ProfilePhoto,
                            configutionExpression =>
                                configutionExpression.MapFrom(u => u.IdentityUser.ProfilePhoto.UrlPthoto))
                                .ForMember(vm => vm.FullName,
                            configutionExpression =>
                                configutionExpression.MapFrom(u => u.IdentityUser.FullName))
                                .ForMember(vm => vm.Username,
                            configutionExpression =>
                                configutionExpression.MapFrom(u => u.IdentityUser.UserName));

                    expression.CreateMap<Team, TeamInfoViewModel>();

                    expression.CreateMap<Student, MemberViewModel>()
                        .ForMember(vm => vm.ProfilePhoto,
                            configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.ProfilePhoto.UrlPthoto))
                            .ForMember(vm => vm.Username,
                            configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.UserName));

                    expression.CreateMap<Project, ProjectTeamViewModel>().ForMember(vm => vm.ProjectPhoto,
                        configutionExpression =>
                            configutionExpression.MapFrom(p => p.ProjectPicture.UrlPthoto));

                    expression.CreateMap<Course, CourseTeamViewModel>().ForMember(vm => vm.PhotoPath,
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.CoursePhoto.UrlPthoto));

                    expression.CreateMap<ApplicationUser, EditUserViewModel>();

                    expression.CreateMap<ApplicationUser, UserInfoViewModel>()
                        .ForMember(vm => vm.ProfilePhoto,
                            configutionExpression => configutionExpression.MapFrom(p => p.ProfilePhoto.UrlPthoto));
                }
            );
        }
    }
}
