using TeamworkSystem.Data.Contracts;

namespace TeamworkSystem.Services
{
    public abstract class Service
    {
        protected ITeamworkSystemData data;

        protected Service(ITeamworkSystemData data)
        {
            this.data = data;
        }
    }
}
