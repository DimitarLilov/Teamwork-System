using TeamworkSystem.Models.ViewModels.Courses;

namespace TeamworkSystem.Services.Contracts
{
    public interface ICoursesService
    {
        CourseInfoViewModel GetCourse(int id);
        AllCoursesViewModel GetAllCourse();
        bool ContainsCourse(int id);
    }
}
