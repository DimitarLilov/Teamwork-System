namespace TeamworkSystem.Services.Contracts
{
    using TeamworkSystem.Models.ViewModels.Courses;

    public interface ICoursesService
    {
        CourseInfoViewModel GetCourse(int id);

        AllCoursesViewModel GetAllCourse();

        bool ContainsCourse(int id);
    }
}
