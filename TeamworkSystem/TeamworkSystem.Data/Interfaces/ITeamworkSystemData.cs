using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data.Interfaces
{
    public interface ITeamworkSystemData
    {
        Repository<Project> Projects { get; }

        Repository<Assistent> Assistents { get; }
        
        Repository<Student> Students { get; }
        
        Repository<Trainer> Trainers { get; }
        
        Repository<Course> Courses { get; }
        
        Repository<Criteria> Criteria { get; }
        
        Repository<Message> Messages { get; }
        
        Repository<Photo> Photos { get; }
        
        Repository<ProjectCriteria> ProjectCriteria { get; }
        
        Repository<Skill> Skills { get; }
        
        Repository<Team> Teams { get; }
        
        Repository<TeamTask> TeamTasks { get; }


        ITeamworkSystemContext Context { get; }

        int SaveChanges();
    }
}
