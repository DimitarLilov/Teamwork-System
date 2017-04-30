using System.Data.Entity;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data.Contracts
{
    public interface ITeamworkSystemContext
    {
        IDbSet<Project> Projects { get; }

        IDbSet<Assistent> Assistents { get; }

        IDbSet<Student> Students { get; }

        IDbSet<Trainer> Trainers { get; }

        IDbSet<Course> Courses { get; }

        IDbSet<Criteria> Criteria { get; }

        IDbSet<Message> Messages { get; }

        IDbSet<Photo> Photos { get; }

        IDbSet<ProjectPoint> ProjectCriteria { get; }

        IDbSet<Skill> Skills { get; }

        IDbSet<Team> Teams { get; }

        IDbSet<TeamTask> TeamTasks { get; }
        IDbSet<Comment> Comments { get; }


        DbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
