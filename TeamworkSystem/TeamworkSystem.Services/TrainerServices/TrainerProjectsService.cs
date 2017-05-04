using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.ViewModels.Trainer.Projects;

namespace TeamworkSystem.Services.TrainerServices
{
    public class TrainerProjectsService : Service
    {
        public TrainerProjectsService(ITeamworkSystemData data) : base(data)
        {
        }

        public TrainerAllProjectsViewModel GrtAllProjects(int? page, string username)
        {
            var projects =
                this.data.Trainers.FindByPredicate(a => a.IdentityUser.UserName == username)
                    .LeadingCourses.SelectMany(c => c.Projects);

            TrainerAllProjectsViewModel vm = new TrainerAllProjectsViewModel();
            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<TrainerProjectViewModel>>(projects);

            var projectsPage = vm.Projects;
            var pager = new Pager(projectsPage.Count(), page);

            vm.Projects = projectsPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }

        public TrainerProjectDetailsViewModel GetProjectDetails(string username ,int id)
        {

            var project = this.data.Projects.GetById(id);
            var trainerCriteria =
                this.data.ProjectCriteria.GetAll().Where(p => p.ProjectId == id).Where(p => p.PointTrainer.IdentityUser.UserName == username);
            var assistentsCriteria =
                this.data.ProjectCriteria.GetAll().Where(p => p.ProjectId == id).Where(p => p.PointTrainer.IdentityUser.UserName != username);

            TrainerProjectDetailsViewModel vm = new TrainerProjectDetailsViewModel();
            vm.Project = Mapper.Map<Project, TrainerProjectViewModel>(project);
            vm.AsistentsCriteria =
                Mapper.Map<IEnumerable<ProjectPoint>, IEnumerable<TrainerProjectAssistentsCriteriaViewModel>>(assistentsCriteria);
            vm.TrainerCriteria = Mapper.Map<IEnumerable<ProjectPoint>, IEnumerable<TrainerProjectCriteriaViewModel>>(trainerCriteria);

            return vm;
        }

        public bool LeadingCoursesProject(string username, int id)
        {
            var project = this.data.Projects.GetById(id);
            var trainer =
                this.data.Trainers.FindByPredicate(t => t.IdentityUser.UserName == username)
                    .LeadingCourses.SelectMany(c => c.Projects);
            if (trainer.Contains(project))
            {
                return true;
            }
            return false;
        }
    }
}
