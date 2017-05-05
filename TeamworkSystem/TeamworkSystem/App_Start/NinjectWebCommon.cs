[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TeamworkSystem.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TeamworkSystem.App_Start.NinjectWebCommon), "Stop")]

namespace TeamworkSystem.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using TeamworkSystem.Services.Contracts.Trainers;
    using TeamworkSystem.Services.TrainerServices;
    using TeamworkSystem.Data;
    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Services.AdminServices;
    using TeamworkSystem.Services.Contracts.Admin;
    using TeamworkSystem.Services.AssistantServices;
    using TeamworkSystem.Services.Contracts.Assistans;
    using TeamworkSystem.Services.Contracts;
    using TeamworkSystem.Services;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITeamworkSystemData>().To<TeamworkSystemData>();
            kernel.Bind<ITeamworkSystemContext>().To<TeamworkSystemContext>();
            kernel.Bind<ITrainerCoursesService>().To<TrainerCoursesService>();
            kernel.Bind<ITrainerHomeService>().To<TrainerHomeService>();
            kernel.Bind<ITrainerProjectsService>().To<TrainerProjectsService>();
            kernel.Bind<IAdminCoursesService>().To<AdminCoursesService>();
            kernel.Bind<IAdminHomeService>().To<AdminHomeService>();
            kernel.Bind<IAdminProjectsService>().To<AdminProjectsService>();
            kernel.Bind<IAdminTeamsService>().To<AdminTeamsService>();
            kernel.Bind<IAdminUsersService>().To<AdminUsersService>();
            kernel.Bind<IAssistantCoursesService>().To<AssistantCoursesService>();
            kernel.Bind<IAssistantHomeService>().To<AssistantHomeService>();
            kernel.Bind<IAssistantProjectsService>().To<AssistantProjectsService>();
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<ICoursesService>().To<CoursesService>();
            kernel.Bind<IHomeService>().To<HomeService>();
            kernel.Bind<IProjectsService>().To<ProjectsService>();
            kernel.Bind<ITeamsService>().To<TeamsService>();
            kernel.Bind<IUsersService>().To<UsersService>();
        }        
    }
}
