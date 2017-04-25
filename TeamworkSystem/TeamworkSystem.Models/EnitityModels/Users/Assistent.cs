using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamworkSystem.Models.EnitityModels.Users
{
    public class Assistent
    {
        public Assistent()
        {
            this.AssistingCourses = new HashSet<Course>();
            this.ProjectPoints = new HashSet<ProjectPoint>();
        }

        public int Id { get; set; }

        public string IdenityUserId { get; set; }

        [ForeignKey("IdenityUserId")]
        public virtual ApplicationUser IdentityUser { get; set; }

        public virtual ICollection<Course> AssistingCourses { get; set; }

        public virtual ICollection<ProjectPoint> ProjectPoints { get; set; }

    }
}
