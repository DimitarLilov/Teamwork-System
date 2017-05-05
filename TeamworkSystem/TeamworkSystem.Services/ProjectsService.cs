using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.BindingModels.Courses;
using TeamworkSystem.Models.BindingModels.Projects;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;
using TeamworkSystem.Services.Contracts;
using TeamworkSystem.Utillities.Constants;

namespace TeamworkSystem.Services
{
   

    public class ProjectsService : Service, IProjectsService
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
                this.data.SaveChanges();
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

                if (isTrainerAssess || isAssistentAssess)
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

            public bool ContainsProject(int id)
            {
                if (this.data.Projects.FindByPredicate(p => p.Id == id) != null)
                {
                    return true;
                }
                return false;
            }

            public bool ContainsUser(int id, string username)
            {
                var members = this.data.Projects.GetById(id).Team.Members.Select(m => m.IdentityUser.UserName);
                if (members.Contains(username))
                {
                    return true;
                }
                return false;
            }

            public EditProjectViewModel GetEditProject(int id)
            {
                Project project = this.data.Projects.GetById(id);
                return Mapper.Map<Project, EditProjectViewModel>(project);
            }

            public void EditProject(int id, EditProjectBindingModel binding)
            {
                Project project = this.data.Projects.GetById(id);
                project.Description = binding.Description;
                project.Repository = binding.Repository;
                project.LiveDemo = binding.LiveDemo;
                project.IsPublic = binding.IsPublic;

                this.data.SaveChanges();
            }

            public decimal GetGrade(int id)
            {
                return this.data.Projects.GetById(id).Grade;
            }

            public bool ProjectIsPublic(int id)
            {
                if (this.data.Projects.GetById(id).IsPublic)
                {
                    return true;
                }
                return false;
            }

            public void AddImage(string pic, int id)
            {
                var path = PathConstants.ProjectPath + pic;
                Photo photo = new Photo()
                {
                    UrlPthoto = path
                };

                this.data.Photos.Insert(photo);
                this.data.Projects.GetById(id).ProjectPicture = photo;
                this.data.SaveChanges();
            }

            public void AddImageInGallery(string pic, int id)
            {
                var project = this.data.Projects.GetById(id);

                var path = PathConstants.ProjectGalleryPath + pic;
                Photo photo = new Photo()
                {
                    UrlPthoto = path
                };
                Album album = new Album()
                {
                    Name = project.Name
                };
                album.Photos.Add(photo);
                project.Photos = album;
                this.data.Photos.Insert(photo);
                this.data.Albums.Insert(album);
                this.data.SaveChanges();
            }

            public bool ContainsProjectGalery(int id)
            {
                var project = this.data.Projects.GetById(id);
                if (project.Photos != null)
                {
                    return true;
                }
                return false;
            }

            public IEnumerable<ProjectGalleryViewModel> GetGalery(int id)
            {
                var album = this.data.Projects.GetById(id).Photos.Photos.Take(4);

                return Mapper.Map<IEnumerable<Photo>, IEnumerable<ProjectGalleryViewModel>>(album);
            }

        public AllProjectsViewModel GetAllPublicProjects()
        {
            AllProjectsViewModel vm = new AllProjectsViewModel();

            IEnumerable<Project> projects = this.data.Projects.GetAll().Where(p => p.IsPublic);

            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

            return vm;
        }

        public bool ContainsCriteria(int id)
        {
            if (this.data.Courses.GetById(id).Criteria.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
    }