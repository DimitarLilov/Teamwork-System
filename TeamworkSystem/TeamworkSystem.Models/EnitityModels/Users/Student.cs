using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamworkSystem.Models.EnitityModels.Users
{
    public class Student
    {
        public Student()
        {
            this.Teams = new HashSet<Team>();
        }
        public int Id { get; set; }
        public string IdenityUserId { get; set; }

        [ForeignKey("IdenityUserId")]
        public virtual ApplicationUser IdentityUser { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
