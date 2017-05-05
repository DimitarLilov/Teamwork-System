using TeamworkSystem.Models.ViewModels.Trainer.Projects;

namespace TeamworkSystem.Services.Contracts.Trainers
{
    public interface ITrainerProjectsService
    {
        TrainerAllProjectsViewModel GrtAllProjects(int? page, string username);

        TrainerProjectDetailsViewModel GetProjectDetails(string username, int id);

        bool LeadingCoursesProject(string username, int id);
    }
}
