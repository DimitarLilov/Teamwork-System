using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using TeamworkSystem.Models.BindingModels.Courses;
using TeamworkSystem.Models.BindingModels.Projects;
using TeamworkSystem.Models.BindingModels.Teams;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;
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

                    expression.CreateMap<Student, SelectMemberViewModel>()
                        .ForMember(vm => vm.ProfilePhoto,
                            configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.ProfilePhoto.UrlPthoto))
                            .ForMember(vm => vm.Username,
                            configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.UserName))
                            .ForMember(vm => vm.FullName,
                            configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.FullName));

                    expression.CreateMap<Student, MemberViewModel>()
                        .ForMember(vm => vm.ProfilePhoto,
                            configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.ProfilePhoto.UrlPthoto))
                            .ForMember(vm => vm.Username,
                            configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.UserName));

                    expression.CreateMap<Project, ProjectViewModel>().ForMember(vm => vm.ProjectPhoto,
                        configutionExpression =>
                            configutionExpression.MapFrom(p => p.ProjectPicture.UrlPthoto));

                    expression.CreateMap<Course, CourseViewModel>().ForMember(vm => vm.PhotoPath,
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.CoursePhoto.UrlPthoto));

                    expression.CreateMap<ApplicationUser, EditUserViewModel>();


                    expression.CreateMap<ApplicationUser, UserInfoViewModel>()
                        .ForMember(vm => vm.ProfilePhoto,
                            configutionExpression => configutionExpression.MapFrom(p => p.ProfilePhoto.UrlPthoto));

                    expression.CreateMap<Team, DashboardInfoViewModel>()
                        .ForMember(vm => vm.ProjectsCount,
                            configutionExpression => configutionExpression.MapFrom(t => t.Projects.Count));

                    expression.CreateMap<TeamTask, TaskViewModel>()
                        .ForMember(vm => vm.Author,
                            configutionExpression => configutionExpression.MapFrom(s => s.Author.IdentityUser.FullName));

                    expression.CreateMap<Project, ProjectInfoViewModel>()
                        .ForMember(vm => vm.ProjectPicture, configutionExpression =>
                            configutionExpression.MapFrom(p => p.ProjectPicture.UrlPthoto))
                            .ForMember(vm => vm.CommentsCount, configutionExpression =>
                            configutionExpression.MapFrom(p => p.Comments.Count));

                    expression.CreateMap<Criteria, CriteriaViewModel>()
                        .ForMember(vm => vm.Id, configutionExpression =>
                            configutionExpression.MapFrom(c => c.Id))
                            .ForMember(vm => vm.Name, configutionExpression =>
                            configutionExpression.MapFrom(c => c.Name));

                    expression.CreateMap<Comment, CommentViewModel>()
                        .ForMember(vm => vm.FullName,
                            configutionExpression => configutionExpression.MapFrom(c => c.Author.IdentityUser.FullName))
                            .ForMember(vm => vm.Username,
                            configutionExpression => configutionExpression.MapFrom(c => c.Author.IdentityUser.UserName))
                            .ForMember(vm => vm.UserPhoto,
                            configutionExpression => configutionExpression.MapFrom(c => c.Author.IdentityUser.ProfilePhoto.UrlPthoto));

                    expression.CreateMap<Course, CourseInfoViewModel>()
                       .ForMember(vm => vm.CoursePhoto, configutionExpression =>
                           configutionExpression.MapFrom(c => c.CoursePhoto.UrlPthoto))
                           .ForMember(vm => vm.TrainerUsername, configutionExpression =>
                           configutionExpression.MapFrom(c => c.Trainer.IdentityUser.UserName))
                           .ForMember(vm => vm.TrainerFullName, configutionExpression =>
                           configutionExpression.MapFrom(c => c.Trainer.IdentityUser.FullName))
                           .ForMember(vm => vm.ProjectCount, configutionExpression =>
                           configutionExpression.MapFrom(c => c.Projects.Count));


                    expression.CreateMap<CriteriaBindingModel, ProjectPoint>()
                    .ForMember(vm => vm.CriteriaId, configutionExpression =>
                            configutionExpression.MapFrom(c => c.CriteriaId))
                            .ForMember(vm => vm.Value, configutionExpression =>
                            configutionExpression.MapFrom(c => c.Point));

                    expression.CreateMap<CommentBindingModel, Comment>();

                    expression.CreateMap<CreateTeamBindingModel, Team>();
                }
            );
        }
    }
}
