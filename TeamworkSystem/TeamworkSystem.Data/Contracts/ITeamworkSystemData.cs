﻿using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data.Contracts
{
    public interface ITeamworkSystemData
    {
        IRepository<Project> Projects { get; }

        IRepository<Assistent> Assistents { get; }

        IRepository<Student> Students { get; }

        IRepository<Trainer> Trainers { get; }

        IRepository<Course> Courses { get; }

        IRepository<Criteria> Criteria { get; }

        IRepository<Message> Messages { get; }

        IRepository<Photo> Photos { get; }

        IRepository<ProjectCriteria> ProjectCriteria { get; }

        IRepository<Skill> Skills { get; }

        IRepository<Team> Teams { get; }

        IRepository<TeamTask> TeamTasks { get; }


        ITeamworkSystemContext Context { get; }

        int SaveChanges();
    }
}
