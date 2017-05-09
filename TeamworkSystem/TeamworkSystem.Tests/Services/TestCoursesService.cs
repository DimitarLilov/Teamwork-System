namespace TeamworkSystem.Tests.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.ViewModels.Courses;
    using TeamworkSystem.Models.ViewModels.Projects;
    using TeamworkSystem.Services;

    [TestClass]
    public class TestCoursesService : BaseTest
    {
        private CoursesService coursesService;

        [TestInitialize]
        public void Init()
        {
            this.coursesService = new CoursesService(this.Data);
        }

        [TestMethod]
        public void Test_CurseById_Should_Return_CourseInfoViewModel()
        {
            // Arrange
            var course = this.Data.Courses.GetById(1);
            CourseInfoViewModel vm = Mapper.Map<CourseInfoViewModel>(course);
            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(course.Projects);

            // Act
            CourseInfoViewModel serviceGetResult = this.coursesService.GetCourse(1);

            // Assert
            Assert.AreEqual(vm.Name, serviceGetResult.Name);
        }

        [TestMethod]
        public void Test_CurseAll_Should_Return_AllCoursesViewModel()
        {
            // Arrange
            AllCoursesViewModel vms = Mapper.Map<AllCoursesViewModel>(this.Data.Courses.GetAll());

            // Act
            AllCoursesViewModel serviceGetAllResult = this.coursesService.GetAllCourse();

            // Assert
            Assert.AreEqual(vms.Courses.Count(), serviceGetAllResult.Courses.Count());
        }
    }
}
