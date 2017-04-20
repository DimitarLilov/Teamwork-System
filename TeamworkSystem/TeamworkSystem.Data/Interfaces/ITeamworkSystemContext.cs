using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data.Interfaces
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

        IDbSet<ProjectCriteria> ProjectCriteria { get; }

        IDbSet<Skill> Skills { get; }

        IDbSet<Team> Teams { get; }

        IDbSet<TeamTask> TeamTasks { get; }


        IdentityDbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
