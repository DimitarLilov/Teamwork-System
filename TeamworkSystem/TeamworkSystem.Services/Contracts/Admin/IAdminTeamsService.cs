namespace TeamworkSystem.Services.Contracts.Admin
{
    using TeamworkSystem.Models.ViewModels.Admin.Teams;

    public interface IAdminTeamsService
    {
        AdminAllTeamsViewModel GetAllTeams(int? page);

        AdminTeamDetailsViewModel GetTeamDetails(int id);
    }
}
