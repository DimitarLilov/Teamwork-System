namespace TeamworkSystem.Data.Moks
{
    using TeamworkSystem.Data.Contracts;
    using TeamworkSystem.Data.Moks.Repositories;
    using TeamworkSystem.Models.EnitityModels;
    using TeamworkSystem.Models.EnitityModels.Users;

    public class FakeTeamworkSystemData : ITeamworkSystemData
    {
        private readonly ITeamworkSystemContext context;

        public FakeTeamworkSystemData(ITeamworkSystemContext context)
        {
            this.context = context;
        }

        public IRepository<Project> Projects => new FakeProjectRepository(this.context);

        public IRepository<Assistent> Assistents => new FakeAssistantRepository(this.context);

        public IRepository<Student> Students => new FakeStudentRepository(this.context);

        public IRepository<Trainer> Trainers => new FakeTrainerRepository(this.context);

        public IRepository<Course> Courses => new FakeCourseRepository(this.context);

        public IRepository<Criteria> Criteria => new FakeCriteriaRepository(this.context);

        public IRepository<Message> Messages => new FakeMessageRepository(this.context);

        public IRepository<Photo> Photos => new FakePhotoRepository(this.context);

        public IRepository<ProjectPoint> ProjectCriteria => new FakeProjectPointRepository(this.context);

        public IRepository<Skill> Skills => new FakeSkillRepository(this.context);

        public IRepository<Team> Teams => new FakeTeamRepository(this.context);

        public IRepository<TeamTask> TeamTasks => new FakeTeamTaskRepository(this.context);

        public IRepository<ApplicationUser> User => new FakeApplicationUserRepository(this.context);

        public IRepository<Comment> Comments => new FakeCommentRepository(this.context);

        public IRepository<Album> Albums => new FakeAlbumRepository(this.context);

        public ITeamworkSystemContext Context => this.context;

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
