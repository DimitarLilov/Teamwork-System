using System.Collections.Generic;

namespace TeamworkSystem.Models.EnitityModels.Users
{
    public class Trainer
    {
        public Trainer()
        {
            this.LeadingCourses = new HashSet<Course>();
            this.GradeProject = new HashSet<ProjectCriteria>();
        }

        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Course> LeadingCourses { get; set; }

        public virtual ICollection<ProjectCriteria> GradeProject { get; set; }
    }
}
