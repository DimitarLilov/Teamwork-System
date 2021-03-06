﻿namespace TeamworkSystem.Data.Contracts
{
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.EnitityModels.Users;

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

        IRepository<ProjectPoint> ProjectCriteria { get; }

        IRepository<Skill> Skills { get; }

        IRepository<Team> Teams { get; }

        IRepository<TeamTask> TeamTasks { get; }

        IRepository<ApplicationUser> User { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Album> Albums { get; }

        ITeamworkSystemContext Context { get; }

        int SaveChanges();
    }
}
