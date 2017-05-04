using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.ViewModels.Courses;
using TeamworkSystem.Models.ViewModels.Projects;

namespace TeamworkSystem.Services
{
    public class CoursesService : Service
    {
        public CoursesService(ITeamworkSystemData data) : base(data)
        {
        }

        public CourseInfoViewModel GetCourse(int id)
        {
            Course course = this.data.Courses.FindByPredicate(c => c.Id == id);

            CourseInfoViewModel vm = Mapper.Map<Course, CourseInfoViewModel>(course);

            IEnumerable<Project> projects = course.Projects.Where(p => p.IsPublic);

            vm.Projects = Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectViewModel>>(projects);

            return vm;
        }

        public AllCoursesViewModel GetAllCourse()
        {
            AllCoursesViewModel vm = new AllCoursesViewModel();
            IEnumerable<Course> courses = this.data.Courses.GetAll();
            vm.Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return vm;
        }

        public bool ContainsCourse(int id)
        {
            if (this.data.Courses.FindByPredicate(c => c.Id == id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
