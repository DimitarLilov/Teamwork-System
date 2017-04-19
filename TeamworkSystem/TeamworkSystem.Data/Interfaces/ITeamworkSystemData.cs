using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;

namespace TeamworkSystem.Data.Interfaces
{
    public interface ITeamworkSystemData
    {
        Repository<Project> Projects { get; }

        ITeamworkSystemContext Context { get; }

        int SaveChanges();
    }
}
