using TeamworkSystem.Data;

namespace TeamworkSystem.Services
{
    public abstract class Service
    {
        protected TeamworkSystemData data;

        protected Service(TeamworkSystemData data)
        {
            this.data = data;
        }
    }
}
