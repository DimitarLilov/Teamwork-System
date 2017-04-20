using TeamworkSystem.Data.Interfaces;
using TeamworkSystem.Data.Repositories;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;

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

        public Repository<Assistent> Assistents => new Repository<Assistent>(this.context);

        public Repository<Student> Students => new Repository<Student>(this.context);

        public Repository<Trainer> Trainers => new Repository<Trainer>(this.context);

        public Repository<Course> Courses => new Repository<Course>(this.context);

        public Repository<Criteria> Criteria => new Repository<Criteria>(this.context);

        public Repository<Message> Messages => new Repository<Message>(this.context);

        public Repository<Photo> Photos => new Repository<Photo>(this.context);

        public Repository<ProjectCriteria> ProjectCriteria => new Repository<ProjectCriteria>(this.context);

        public Repository<Skill> Skills => new Repository<Skill>(this.context);

        public Repository<Team> Teams => new Repository<Team>(this.context);

        public Repository<TeamTask> TeamTasks => new Repository<TeamTask>(this.context);

        public ITeamworkSystemContext Context => this.context;

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
