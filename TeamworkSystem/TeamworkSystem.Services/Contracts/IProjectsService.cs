using System.Collections.Generic;
using TeamworkSystem.Models.BindingModels.Courses;
using TeamworkSystem.Models.BindingModels.Projects;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;

namespace TeamworkSystem.Services.Contracts
{
    public interface IProjectsService
    {
        ProjectInfoViewModel GetProject(int id);
        AllProjectsViewModel GetAllPublicProjects();
        IEnumerable<CriteriaViewModel> GetProjectCriteria(int projectId);
        IEnumerable<string> GetAssistentsNames(int projectId);
        string GetTreinerName(int projectId);
        void GradeProject(string username, int projectId, IList<CriteriaBindingModel> binding);
        bool IsAssisstent(string username, int id);
        bool IsTreiner(string username, int id);
        bool IsAssess(string username, int projectId);
        bool IsActiveProject(int id);
        void AddComment(int id, CommentBindingModel binding, string username);
        IEnumerable<CommentViewModel> GetComments(int id);
        bool ContainsProject(int id);
        bool ContainsUser(int id, string username);
        EditProjectViewModel GetEditProject(int id);
        void EditProject(int id, EditProjectBindingModel binding);
        decimal GetGrade(int id);
        bool ProjectIsPublic(int id);
        void AddImage(string pic, int id);
        void AddImageInGallery(string pic, int id);
        bool ContainsProjectGalery(int id);
        IEnumerable<ProjectGalleryViewModel> GetGalery(int id);
        bool ContainsCriteria(int id);
    }
}
