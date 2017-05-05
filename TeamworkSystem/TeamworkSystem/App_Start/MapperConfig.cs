using System.Linq;
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
    public class MapperConfig
    {
        public static void ConfigureAutomapper()
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
                        configutionExpression =>
                            configutionExpression.MapFrom(s => s.IdentityUser.ProfilePhoto.UrlPthoto))
                    .ForMember(vm => vm.Username,
                        configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.UserName))
                    .ForMember(vm => vm.FullName,
                        configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.FullName));

                expression.CreateMap<Student, MemberViewModel>()
                    .ForMember(vm => vm.ProfilePhoto,
                        configutionExpression =>
                            configutionExpression.MapFrom(s => s.IdentityUser.ProfilePhoto.UrlPthoto))
                    .ForMember(vm => vm.Username,
                        configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.UserName));

                expression.CreateMap<Student, BoardMemberViewModel>()
                    .ForMember(vm => vm.ProfilePhoto,
                        configutionExpression =>
                            configutionExpression.MapFrom(s => s.IdentityUser.ProfilePhoto.UrlPthoto))
                    .ForMember(vm => vm.Username,
                        configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.UserName))
                    .ForMember(vm => vm.FullName,
                        configutionExpression => configutionExpression.MapFrom(s => s.IdentityUser.FullName));

                expression.CreateMap<Project, ProjectViewModel>().ForMember(vm => vm.ProjectPhoto,
                    configutionExpression =>
                        configutionExpression.MapFrom(p => p.ProjectPicture.UrlPthoto));

                expression.CreateMap<Course, CourseViewModel>().ForMember(vm => vm.PhotoPath,
                    configutionExpression =>
                        configutionExpression.MapFrom(c => c.CoursePhoto.UrlPthoto));

                expression.CreateMap<ApplicationUser, EditUserViewModel>().ForMember(vm => vm.ProfilePicturePath,
                    configutionExpression =>
                        configutionExpression.MapFrom(c => c.ProfilePhoto.UrlPthoto));

                expression.CreateMap<ApplicationUser, AdminUserViewModel>();

                expression.CreateMap<Course, ProjectCoursesViewModel>();

                expression.CreateMap<Team, EditTeamViewModel>();

                expression.CreateMap<Course, AdminEditCourseViewModel>();

                expression.CreateMap<Project, AdminDeleteProjectViewModel>();

                expression.CreateMap<Project, TopProjectsViewModel>().ForMember(vm => vm.Image,
                    configutionExpression =>
                        configutionExpression.MapFrom(p => p.ProjectPicture.UrlPthoto));

                expression.CreateMap<ApplicationUser, AdminUserViewModel>();

                expression.CreateMap<Project, AssistantProjectViewModel>();

                expression.CreateMap<Project, TrainerProjectViewModel>();

                expression.CreateMap<Course, TrainerCourseEditViewModel>();

                expression.CreateMap<Criteria, TrainerCriteriaViewModel>();

                expression.CreateMap<Photo, ProjectGalleryViewModel>()
                    .ForMember(vm => vm.Path,
                        configutionExpression =>
                            configutionExpression.MapFrom(p => p.UrlPthoto));

                expression.CreateMap<ProjectPoint, TrainerProjectAssistentsCriteriaViewModel>().ForMember(vm => vm.Name,
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.PointAssistent.IdentityUser.FullName))
                    .ForMember(vm => vm.Username,
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.PointAssistent.IdentityUser.UserName));

                expression.CreateMap<ProjectPoint, TrainerProjectAssistentsCriteriaViewModel>().ForMember(vm => vm.Name,
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.PointAssistent.IdentityUser.FullName))
                    .ForMember(vm => vm.Username,
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.PointAssistent.IdentityUser.UserName));
                expression.CreateMap<ProjectPoint, TrainerProjectCriteriaViewModel>().ForMember(vm => vm.Name,
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.PointTrainer.IdentityUser.FullName))
                    .ForMember(vm => vm.Username,
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.PointTrainer.IdentityUser.UserName));

                expression.CreateMap<Assistent, TrainerCourseAssistantViewModel>()
                    .ForMember(vm => vm.FullName,
                        configutionExpression =>
                            configutionExpression.MapFrom(a => a.IdentityUser.FullName))
                    .ForMember(vm => vm.Username,
                        configutionExpression =>
                            configutionExpression.MapFrom(a => a.IdentityUser.UserName));

                expression.CreateMap<Trainer, TrainerPanelViewModel>()
                    .ForMember(vm => vm.CoursesCount,
                        configutionExpression =>
                            configutionExpression.MapFrom(a => a.LeadingCourses.Count))
                    .ForMember(vm => vm.ProjectsCount,
                        configutionExpression =>
                            configutionExpression.MapFrom(a => a.LeadingCourses.SelectMany(c => c.Projects).Count()));
                expression.CreateMap<Course, TrainerCourseViewModel>()
                    .ForMember(vm => vm.AssistantsCount,
                        configutionExpression =>
                            configutionExpression.MapFrom(a => a.Assistents.Count));




                expression.CreateMap<Team, AdminTeamViewModel>().ForMember(vm => vm.MembersCount,
                        configutionExpression =>
                            configutionExpression.MapFrom(t => t.Members.Count))
                    .ForMember(vm => vm.ProjectsCount,
                        configutionExpression =>
                            configutionExpression.MapFrom(t => t.Projects.Count));

                expression.CreateMap<Assistent, AssistantPanelViewModel>()
                    .ForMember(vm => vm.CourseCount,
                        configutionExpression =>
                            configutionExpression.MapFrom(a => a.AssistingCourses.Count))
                    .ForMember(vm => vm.ProjectsCount,
                        configutionExpression =>
                            configutionExpression.MapFrom(
                                a => a.AssistingCourses.SelectMany(c => c.Projects.Where(p => p.IsActive)).Count()));

                expression.CreateMap<Student, AdminTeamMembersViewModel>().ForMember(vm => vm.FullName,
                        configutionExpression =>
                            configutionExpression.MapFrom(s => s.IdentityUser.FullName))
                    .ForMember(vm => vm.Username,
                        configutionExpression =>
                            configutionExpression.MapFrom(s => s.IdentityUser.UserName));

                expression.CreateMap<Project, AdminProjectViewModel>()
                    .ForMember(vm => vm.Course,
                        configutionExpression =>
                            configutionExpression.MapFrom(p => p.Course.Name))
                    .ForMember(vm => vm.Team,
                        configutionExpression =>
                            configutionExpression.MapFrom(p => p.Team.Name));

                expression.CreateMap<Project, EditProjectViewModel>();

                expression.CreateMap<Course, AdminCourseViewModel>()
                    .ForMember(vm => vm.TrainerFullName,
                        configutionExpression => configutionExpression.MapFrom(t => t.Trainer.IdentityUser.FullName))
                    .ForMember(vm => vm.TrainerUsername,
                        configutionExpression => configutionExpression.MapFrom(t => t.Trainer.IdentityUser.UserName));

                expression.CreateMap<Course, AssistantCourseViewModel>();

                expression.CreateMap<ApplicationUser, UserInfoViewModel>()
                    .ForMember(vm => vm.ProfilePhoto,
                        configutionExpression => configutionExpression.MapFrom(p => p.ProfilePhoto.UrlPthoto));

                expression.CreateMap<Team, BoardViewModel>();

                expression.CreateMap<Team, BoardInfoViewModel>()
                    .ForMember(vm => vm.ProjectsCount,
                        configutionExpression => configutionExpression.MapFrom(t => t.Projects.Count));

                expression.CreateMap<TeamTask, MyTaskViewModel>();

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
                        configutionExpression =>
                            configutionExpression.MapFrom(c => c.Author.IdentityUser.ProfilePhoto.UrlPthoto));

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
                    .ForMember(p => p.CriteriaId, configutionExpression =>
                        configutionExpression.MapFrom(bm => bm.CriteriaId))
                    .ForMember(p => p.Value, configutionExpression =>
                        configutionExpression.MapFrom(bm => bm.Point));

                expression.CreateMap<CommentBindingModel, Comment>();

                expression.CreateMap<CreateTeamBindingModel, Team>();

                expression.CreateMap<AddProjectBindingModel, Project>();

                expression.CreateMap<AdminCreateCourseBindingModel, Course>();
            });
        }
    }
}

