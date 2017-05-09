namespace TeamworkSystem.Models.EnitityModels
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.EnitityModels.Users;

    public class Team
    {
        public Team()
        {
            this.Projects = new HashSet<Project>();
            this.Messages = new HashSet<Message>();
            this.Members = new HashSet<Student>();
            this.Tasks = new HashSet<TeamTask>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Members { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<TeamTask> Tasks { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
