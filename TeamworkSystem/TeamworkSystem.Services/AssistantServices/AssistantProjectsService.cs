using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.ViewModels.Assistant.Projects;
using TeamworkSystem.Services.Contracts.Assistans;

namespace TeamworkSystem.Services.AssistantServices
{

    public class AssistantProjectsService : Service, IAssistantProjectsService
    {
        public AssistantProjectsService(ITeamworkSystemData data) : base(data)
        {
        }

        public AssistantAllProjectsViewModel GetAllProjects(int? page, string username)
        {
            var projects =
                this.data.Assistents.FindByPredicate(a => a.IdentityUser.UserName == username)
                    .AssistingCourses.SelectMany(c => c.Projects.Where(p => p.IsActive));
            AssistantAllProjectsViewModel vm = new AssistantAllProjectsViewModel
            {
                Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<AssistantProjectViewModel>>(projects)
            };

            var projectsPage = vm.Projects;
            var pager = new Pager(projectsPage.Count(), page);

            vm.Projects = projectsPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }
    }
}
