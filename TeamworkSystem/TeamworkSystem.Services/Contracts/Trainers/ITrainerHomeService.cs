using TeamworkSystem.Models.ViewModels.Trainer.Home;

namespace TeamworkSystem.Services.Contracts.Trainers
{
    public interface ITrainerHomeService
    {
        TrainerPanelViewModel GetTrainerInfo(string username);
    }
}
