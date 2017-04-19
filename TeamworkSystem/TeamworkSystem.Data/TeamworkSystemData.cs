using TeamworkSystem.Data.Interfaces;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data
{
    public class TeamworkSystemData: ITeamworkSystemData
    {
        private readonly ITeamworkSystemContext context;

        public TeamworkSystemData()
            : this(new TeamworkSystemContext())
        {

        }
        public TeamworkSystemData(TeamworkSystemContext context)
        {
            this.context = context;
        }
        public Repository<Project> Projects => new Repository<Project>(this.context);

        public ITeamworkSystemContext Context => this.context;

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

    }
}
