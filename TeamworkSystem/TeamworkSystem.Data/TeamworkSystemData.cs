using System;
using System.Data.Entity.Validation;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data
{
    public class TeamworkSystemData: ITeamworkSystemData
    {
        private readonly ITeamworkSystemContext context;

        public TeamworkSystemData(ITeamworkSystemContext context)
        {
            this.context = context;
        }

        public IRepository<Project> Projects => new Repository<Project>(this.context);

        public IRepository<Assistent> Assistents => new Repository<Assistent>(this.context);

        public IRepository<Student> Students => new Repository<Student>(this.context);

        public IRepository<Trainer> Trainers => new Repository<Trainer>(this.context);

        public IRepository<Course> Courses => new Repository<Course>(this.context);

        public IRepository<Criteria> Criteria => new Repository<Criteria>(this.context);

        public IRepository<Message> Messages => new Repository<Message>(this.context);

        public IRepository<Photo> Photos => new Repository<Photo>(this.context);

        public IRepository<ProjectCriteria> ProjectCriteria => new Repository<ProjectCriteria>(this.context);

        public IRepository<Skill> Skills => new Repository<Skill>(this.context);

        public IRepository<Team> Teams => new Repository<Team>(this.context);

        public IRepository<TeamTask> TeamTasks => new Repository<TeamTask>(this.context);

        public ITeamworkSystemContext Context => this.context;

        public int SaveChanges()
        {
            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                return this.context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            
        }
    }
}
