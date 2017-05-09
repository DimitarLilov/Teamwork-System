namespace TeamworkSystem.Services.Contracts.Trainers
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.BindingModels.Trainer.Courses;
    using TeamworkSystem.Models.ViewModels.Trainer.Courses;

    public interface ITrainerCoursesService
    {
        TrainerAllCourseViewModel GetTrainerCourses(int? page, string username);

        bool LeadingCourses(string username, int id);

        TrainerCourseDetailsViewModel GetCourseDetails(int id);

        void ActivateProject(IEnumerable<TrainerProjectActiveBindingModel> binding);

        TrainerCourseEditViewModel GetEditCourse(int id);

        void EditCourse(int id, TrainerCourseEditBindingModel binding);

        TrainerCourseAssistantsViewModel GetCourseAssistents(int id);

        void AddAssistant(int id, TrainerAddAssistantBindingModel binding);

        bool ContainsUser(string username);

        TrainerCourseCriteriaViewModel GetCourseCriteria(int id);

        void AddCriteria(int id, TrainerCriteriaBindingModel binding);
    }
}
