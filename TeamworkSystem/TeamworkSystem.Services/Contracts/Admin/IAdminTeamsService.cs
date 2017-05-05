using TeamworkSystem.Models.ViewModels.Admin.Teams;

namespace TeamworkSystem.Services.Contracts.Admin
{
    public interface IAdminTeamsService
    {
        AdminAllTeamsViewModel GetAllTeams(int? page);
        AdminTeamDetailsViewModel GetTeamDetails(int id);
    }
}
