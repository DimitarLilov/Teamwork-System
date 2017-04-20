using System;
using System.Collections.Generic;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Models.EnitityModels
{
    public class TeamTask
    {
        public TeamTask()
        {
            this.Members = new HashSet<Student>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsComplet { get; set; }

        public virtual ICollection<Student> Members { get; set; }
    }
}
