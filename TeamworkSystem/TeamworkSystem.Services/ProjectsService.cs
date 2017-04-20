using TeamworkSystem.Data.Contracts;

namespace TeamworkSystem.Services
{
    public class ProjectsService : Service
    {
        public ProjectsService(ITeamworkSystemData data) : base(data)
        {
        }
    }
}
