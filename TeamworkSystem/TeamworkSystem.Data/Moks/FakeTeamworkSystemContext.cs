namespace TeamworkSystem.Data.Moks
{
    using System.Data.Entity;

    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Data.Moks.DbSet;
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.EnitityModels.Users;

    public class FakeTeamworkSystemContext : DbContext, ITeamworkSystemContext
    {
        public FakeTeamworkSystemContext()
        {
            this.Projects = new FakeProjectDbSet();
            this.Assistents = new FakeAssistantDbSet();
            this.Students = new FakeStudentDbSet();
            this.Trainers = new FakeTrainerDbSet();
            this.Courses = new FakeCourseDbSet();
            this.Criteria = new FakeCriteriaDbSet();
            this.Messages = new FakeMessageDbSet();
            this.Photos = new FakePhotoDbSet();
            this.ProjectCriteria = new FakeProjectPointDbSet();
            this.Skills = new FakeSkillDbSet();
            this.Teams = new FakeTeamDbSet();
            this.TeamTasks = new FakeTeamTaskDbSet();
            this.Comments = new FakeCommentDbSet();
            this.Albums = new FakeAlbumDbSet();
        }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<Assistent> Assistents { get; set; }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Trainer> Trainers { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Criteria> Criteria { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Photo> Photos { get; set; }

        public IDbSet<ProjectPoint> ProjectCriteria { get; set; }

        public IDbSet<Skill> Skills { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<TeamTask> TeamTasks { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public DbContext DbContext => new FakeTeamworkSystemContext();

        public new IDbSet<T> Set<T>() where T : class
        {
            return new FakeDbSet<T>();
        }

        public override int SaveChanges()
        {
            return 0;
        }
    }
}
