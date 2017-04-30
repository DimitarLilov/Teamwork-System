using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.BindingModels.Courses;
using TeamworkSystem.Models.BindingModels.Projects;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;

namespace TeamworkSystem.Services
{
    public class ProjectsService : Service
    {
        public ProjectsService(ITeamworkSystemData data) : base(data)
        {
        }

        public ProjectInfoViewModel GetProject(int id)
        {
            Project project = this.data.Projects.FindByPredicate(p => p.Id == id);

            ProjectInfoViewModel vm = Mapper.Map<Project, ProjectInfoViewModel>(project);

            return vm;
        }

        public AllProjectsViewModel GetAllProjects()
        {
            AllProjectsViewModel vm = new AllProjectsViewModel();

            IEnumerable<Project> projects = this.data.Projects.GetAll();

            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

            return vm;
        }

        public IEnumerable<CriteriaViewModel> GetProjectCriteria(int projectId)
        {
            Project project = this.data.Projects.FindByPredicate(p => p.Id == projectId);

            IEnumerable<Criteria> criterias = project.Course.Criteria;

            return Mapper.Map<IEnumerable<Criteria>, IEnumerable<CriteriaViewModel>>(criterias);
        }

        public IEnumerable<string> GetAssistentsNames(int projectId)
        {
            return
                this.data.Projects.FindByPredicate(p => p.Id == projectId)
                    .Course.Assistents.Select(a => a.IdentityUser.UserName);
        }

        public string GetTreinerName(int projectId)
        {
            return this.data.Projects.FindByPredicate(p => p.Id == projectId).Course.Trainer.IdentityUser.UserName;
        }

        public void GradeProject(string username, int projectId, IList<CriteriaBindingModel> binding)
        {

            IEnumerable<ProjectPoint> grade =
                Mapper.Map<IEnumerable<CriteriaBindingModel>, IEnumerable<ProjectPoint>>(binding);

            var projectPoints = grade as ProjectPoint[] ?? grade.ToArray();

            foreach (var point in projectPoints)
            {
                point.ProjectId = projectId;
                if (IsAssisstent(username, projectId))
                {
                    point.PointAssistent =
                        this.data.Assistents.FindByPredicate(a => a.IdentityUser.UserName == username);

                }
                if (IsTreiner(username, projectId))
                {
                    point.PointTrainer =
                        this.data.Trainers.FindByPredicate(t => t.IdentityUser.UserName == username);

                }

                this.data.ProjectCriteria.Insert(point);
            }
            this.Grade(projectId);
            this.data.SaveChanges();
        }

        private void Grade(int projectId)
        {
            var project = this.data.Projects.FindByPredicate(p => p.Id == projectId);
            var averagePoints = project.Points.Average(p => p.Value);
            var trainerCount = project.Points.Where(p => p.PointTrainer != null).Select(p => p.PointTrainer != null).Distinct().Count();
            var assisstentsCount = project.Points.Where(p => p.PointAssistent != null).Select(p => p.PointAssistent != null).Distinct().Count();
            
            project.Grade += averagePoints;
            project.Grade /= (assisstentsCount + trainerCount);
        }


        public bool IsAssisstent(string username, int id)
        {
            var asisstentsName = this.GetAssistentsNames(id).ToArray();

            if (asisstentsName.Contains(username))
            {
                return true;
            }
            return false;
        }

        public bool IsTreiner(string username, int id)
        {
            var trainerName = this.GetTreinerName(id);

            if (trainerName.Contains(username))
            {
                return true;
            }
            return false;
        }

        public bool IsAssess(string username, int projectId)
        {
            var project = this.data.Projects.FindByPredicate(p => p.Id == projectId);

            var assisstent = this.data.Assistents.FindByPredicate(a => a.IdentityUser.UserName == username);
            var trainer = this.data.Trainers.FindByPredicate(a => a.IdentityUser.UserName == username);

            var isAssistentAssess = project.Points.Any(p => p.PointAssistent == assisstent);

            var isTrainerAssess = project.Points.Any(p => p.PointTrainer == trainer);

            if (isTrainerAssess && isAssistentAssess)
            {
                return true;
            }
            return false;
        }

        public bool IsActiveProject(int id)
        {
            return this.data.Projects.FindByPredicate(p => p.Id == id).IsActive;
        }

        public void AddComment(int id, CommentBindingModel binding, string username)
        {
            Comment comment = Mapper.Map<CommentBindingModel, Comment>(binding);

            comment.Author = this.data.Students.FindByPredicate(u => u.IdentityUser.UserName == username);
            comment.PostedDate = DateTime.Now;

            Project project = this.data.Projects.FindByPredicate(p => p.Id == id);
            project.Comments.Add(comment);
            this.data.Comments.Insert(comment);
            this.data.SaveChanges();
        }

        public IEnumerable<CommentViewModel> GetComments(int id)
        {
            IEnumerable<Comment> comments = this.data.Projects.FindByPredicate(p => p.Id == id).Comments;
            return Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentViewModel>>(comments);
        }
    }
}
