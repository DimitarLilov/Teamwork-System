using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public virtual Student Author { get; set; }

        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public bool IsComplet { get; set; }

        public virtual ICollection<Student> Members { get; set; }
    }
}
