namespace TeamworkSystem.Services.AssistantServices
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Models;
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.ViewModels.Assistant.Courses;
    using TeamworkSystem.Models.ViewModels.Assistant.Projects;
    using TeamworkSystem.Services.Contracts.Assistans;

    public class AssistantCoursesService : Service, IAssistantCoursesService
    {
        public AssistantCoursesService(ITeamworkSystemData data) : base(data)
        {
        }

        public AssistantAllCoursesViewModel GetAllCourses(int? page, string username)
        {
            var courses =
                this.data.Assistents.FindByPredicate(a => a.IdentityUser.UserName == username).AssistingCourses;

            AssistantAllCoursesViewModel vm =
                new AssistantAllCoursesViewModel
                {
                    Courses = Mapper
                            .Map<IEnumerable<Course>, IEnumerable<AssistantCourseViewModel>>(courses)
                };

            var coursesPage = vm.Courses;
            var pager = new Pager(courses.Count, page);

            vm.Courses = coursesPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }

        public bool AssistingCourse(int id, string username)
        {
            var assistant = this.data.Assistents.FindByPredicate(a => a.IdentityUser.UserName == username);

            return assistant.AssistingCourses.FirstOrDefault(c => c.Id == id) != null;
        }

        public AssistantCourseDetailsViewModel GetDetails(int id)
        {
            Course course = this.data.Courses.GetById(id);
            IEnumerable<Project> projects = course.Projects.Where(p => p.IsActive);

            AssistantCourseDetailsViewModel vm = new AssistantCourseDetailsViewModel
            {
                Course = Mapper.Map<Course, AssistantCourseViewModel>(course),
                Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<AssistantProjectViewModel>>(projects)
            };
            return vm;
        }
    }
}
