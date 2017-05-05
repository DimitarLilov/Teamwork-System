using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamworkSystem.Models.ViewModels.Home;
using TeamworkSystem.Services;

namespace TeamworkSystem.Tests.Services
{
    [TestClass]
    public class TestHomeService : BaseTest
    {
        private HomeService homeService;

        [TestInitialize]
        public void Init()
        {
            this.homeService = new HomeService(this.Data);
        }

        [TestMethod]
        public void Test_GetTopProject_Should_Return_TopProjectsViewModel()
        {
            // Arrange

            IEnumerable<TopProjectsViewModel> vms =
                Mapper.Map<IEnumerable<TopProjectsViewModel>>(
                    this.Data.Projects.GetAll().OrderByDescending(p => p.Grade).Take(5));

            // Act
            IEnumerable<TopProjectsViewModel> serviceGetTopProject = this.homeService.GetTopProjects();

            // Assert
            Assert.AreEqual(vms.Count(), serviceGetTopProject.Count());
        }
    }
}