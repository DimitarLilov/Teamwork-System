using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamworkSystem.Data.Contracts;
using TeamworkSystem.Models.EnitityModels;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Data
{
    public class TeamworkSystemContext : IdentityDbContext<ApplicationUser>, ITeamworkSystemContext
    {
        public TeamworkSystemContext()
            : base("TeamworkSystemContext", throwIfV1Schema: false)
        {
            
        }

        public static TeamworkSystemContext Create()
        {
            return new TeamworkSystemContext();
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

        public DbContext DbContext => this;

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasMany<TeamTask>(s => s.Tasks).WithMany(t => t.Members).Map(cs => { cs.MapLeftKey("StudentId"); cs.MapRightKey("TaskId"); cs.ToTable("StudentTask"); });
            base.OnModelCreating(modelBuilder);
        }


    }
}