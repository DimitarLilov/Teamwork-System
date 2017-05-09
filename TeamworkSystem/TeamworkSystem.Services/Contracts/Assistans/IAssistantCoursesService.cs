namespace TeamworkSystem.Services.Contracts.Assistans
{
    using TeamworkSystem.Models.ViewModels.Assistant.Courses;

    public interface IAssistantCoursesService
    {
        AssistantAllCoursesViewModel GetAllCourses(int? page, string username);

        bool AssistingCourse(int id, string username);

        AssistantCourseDetailsViewModel GetDetails(int id);
    }
}
