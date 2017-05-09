namespace TeamworkSystem.Services.Contracts.Trainers
{
    using TeamworkSystem.Models.ViewModels.Trainer.Home;

    public interface ITrainerHomeService
    {
        TrainerPanelViewModel GetTrainerInfo(string username);
    }
}
