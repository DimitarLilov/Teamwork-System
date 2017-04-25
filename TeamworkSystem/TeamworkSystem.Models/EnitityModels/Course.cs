using System;
using System.Collections.Generic;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Models.EnitityModels
{
    public class Course
    {
        public Course()
        {
            this.Assistents = new HashSet<Assistent>();
            this.Projects = new HashSet<Project>();
            this.Criteria = new HashSet<Criteria>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Photo CoursePhoto { get; set; }

        public decimal MaxGrade { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Trainer Trainer { get; set; }

        public virtual ICollection<Assistent> Assistents { get; set; }

        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<Criteria> Criteria { get; set; }

    }
}
