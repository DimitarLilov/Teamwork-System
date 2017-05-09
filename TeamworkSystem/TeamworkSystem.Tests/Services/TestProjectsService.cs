namespace TeamworkSystem.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamworkSystem.Models.BindingModels.Projects;
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.ViewModels.Courses;
    using TeamworkSystem.Models.ViewModels.Projects;
    using TeamworkSystem.Services;

    [TestClass]
    public class TestProjectsService : BaseTest
    {

        private ProjectsService projectsService;

        [TestInitialize]
        public void Init()
        {
            this.projectsService = new ProjectsService(this.Data);
        }

        [TestMethod]
        public void Test_ProjectById_Should_Return_ProjectInfoViewModel()
        {
            // Arrange
            var project = this.Data.Projects.GetById(1);
            ProjectInfoViewModel vm = Mapper.Map<ProjectInfoViewModel>(project);

            // Act
            ProjectInfoViewModel serviceGetResult = this.projectsService.GetProject(1);

            // Assert
            Assert.AreEqual(vm.Name, serviceGetResult.Name);
        }

        [TestMethod]
        public void Test_GetAllPublicProject_Should_Return_AllProjectsViewModel()
        {
            // Arrange
            AllProjectsViewModel vms = new AllProjectsViewModel();

            IEnumerable<Project> projects = this.Data.Projects.GetAll().Where(p => p.IsPublic);

            vms.Projects = Mapper.Map<IEnumerable<ProjectViewModel>>(projects);


            // Act
            AllProjectsViewModel serviceGetResult = this.projectsService.GetAllPublicProjects();

            // Assert
            Assert.AreEqual(vms.Projects.Count(), serviceGetResult.Projects.Count());
        }

        [TestMethod]
        public void Test_GetProjectCriteria_Should_Return_AllCriteriaViewModel()
        {
            // Arrange
            Project project = this.Data.Projects.FindByPredicate(p => p.Id == 1);

            IEnumerable<Criteria> criterias = project.Course.Criteria;

            var vms = Mapper.Map<IEnumerable<CriteriaViewModel>>(criterias);


            // Act
            IEnumerable<CriteriaViewModel> serviceGetResult = this.projectsService.GetProjectCriteria(1);

            // Assert
            Assert.AreEqual(vms.Count(), serviceGetResult.Count());
        }

        [TestMethod]
        public void Test_GetAssistantsNames_Should_Return_AssistantsNames()
        {
            // Arrange
            var assistants = this.Data.Projects.FindByPredicate(p => p.Id == 1)
                .Course.Assistents.Select(a => a.IdentityUser.UserName);


            // Act
            IEnumerable<string> serviceGetResult = this.projectsService.GetAssistentsNames(1);

            // Assert
            Assert.AreEqual(assistants.Count(), serviceGetResult.Count());
        }

        [TestMethod]
        public void Test_GetTreinerName_Should_Return_TrainerName()
        {
            // Arrange
            var trainer = this.Data.Projects.FindByPredicate(p => p.Id == 1)
                .Course.Trainer.IdentityUser.UserName;


            // Act
            string serviceGetResult = this.projectsService.GetTreinerName(1);

            // Assert
            Assert.AreEqual(trainer, serviceGetResult);
        }

        [TestMethod]
        public void Test_GetAllComments_Should_Return_AllComents()
        {
            // Arrange
            IEnumerable<Comment> comments = this.Data.Projects.FindByPredicate(p => p.Id == 1).Comments;
            var vms = Mapper.Map<IEnumerable<CommentViewModel>>(comments);


            // Act
            IEnumerable<CommentViewModel> serviceGetResult = this.projectsService.GetComments(1);

            // Assert
            Assert.AreEqual(vms.Count(), serviceGetResult.Count());
        }

        [TestMethod]
        public void Test_GetGalery_Should_Return_ProjectGallery()
        {
            // Arrange
            var album = this.Data.Projects.GetById(1).Photos.Photos.Take(4);

            var vms = Mapper.Map<IEnumerable<ProjectGalleryViewModel>>(album);


            // Act
            IEnumerable<ProjectGalleryViewModel> serviceGetResult = this.projectsService.GetGalery(1);

            // Assert
            Assert.AreEqual(vms.Count(), serviceGetResult.Count());
        }

        [TestMethod]
        public void Test_EditProject_Should_Edit_Project()
        {
            // Arange
            EditProjectBindingModel bm = new EditProjectBindingModel()
            {
                Description = "nesthto",
                IsPublic = true,
                LiveDemo = "google.bg",
                Repository = "softuni.bg"
            };

            // Act
            this.projectsService.EditProject(1,bm);

            // Assert
            Assert.AreEqual(bm.Description, this.Data.Projects.GetById(1).Description);
        }
    }
}
