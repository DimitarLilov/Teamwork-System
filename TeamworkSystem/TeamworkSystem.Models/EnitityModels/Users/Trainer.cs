using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamworkSystem.Models.EnitityModels.Users
{
    public class Trainer
    {
        public Trainer()
        {
            this.LeadingCourses = new HashSet<Course>();
            this.ProjectPoints = new HashSet<ProjectPoint>();
        }

        public int Id { get; set; }

        public string IdenityUserId { get; set; }

        [ForeignKey("IdenityUserId")]
        public virtual ApplicationUser IdentityUser { get; set; }

        public virtual ICollection<Course> LeadingCourses { get; set; }

        public virtual ICollection<ProjectPoint> ProjectPoints { get; set; }
    }
}
