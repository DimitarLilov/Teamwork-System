using System.Collections.Generic;

namespace TeamworkSystem.Models.EnitityModels.Users
{
    public class Student
    {
        public Student()
        {
            this.Teams = new HashSet<Team>();
        }
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
