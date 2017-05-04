using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.ViewModels.Assistant.Courses;
using TeamworkSystem.Models.ViewModels.Assistant.Projects;

namespace TeamworkSystem.Services.AssistantServices
{
    public class AssistantCoursesService : Service
    {
        public AssistantCoursesService(ITeamworkSystemData data) : base(data)
        {
        }

        public AssistantAllCoursesViewModel GetAllCourses(int? page, string username)
        {
            var courses =
                this.data.Assistents.FindByPredicate(a => a.IdentityUser.UserName == username).AssistingCourses;
            AssistantAllCoursesViewModel vm = new AssistantAllCoursesViewModel();
            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<AssistantCourseViewModel>>(courses);

            var coursesPage = vm.Courses;
            var pager = new Pager(courses.Count(), page);

            vm.Courses = coursesPage.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize);
            vm.Pager = pager;

            return vm;
        }

        public bool AssistingCourse(int id, string username)
        {
            var assistant = this.data.Assistents.FindByPredicate(a => a.IdentityUser.UserName == username);
            if (assistant.AssistingCourses.FirstOrDefault(c => c.Id == id) != null)
            {
                return true;
            }
            return false;
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
