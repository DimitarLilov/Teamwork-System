namespace TeamworkSystem.Data
{
    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Data.Repositories;
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.EnitityModels.Users;

    public class TeamworkSystemData : ITeamworkSystemData
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

        public IRepository<ProjectPoint> ProjectCriteria => new Repository<ProjectPoint>(this.context);

        public IRepository<Skill> Skills => new Repository<Skill>(this.context);

        public IRepository<Team> Teams => new Repository<Team>(this.context);

        public IRepository<TeamTask> TeamTasks => new Repository<TeamTask>(this.context);

        public IRepository<ApplicationUser> User => new Repository<ApplicationUser>(this.context);

        public IRepository<Comment> Comments => new Repository<Comment>(this.context);

        public IRepository<Album> Albums => new Repository<Album>(this.context);

        public ITeamworkSystemContext Context => this.context;

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
