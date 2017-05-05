using System.Collections.Generic;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Models.EnitityModels
{
    public class Point
    {
        public Point()
        {
            this.Trainer = new HashSet<Trainer>();
            this.Assistents = new HashSet<Assistent>();
        }
        public int Id { get; set; }

        public virtual Criteria Criteria { get; set; }

        public decimal Value { get; set; }

        public ICollection<Trainer> Trainer { get; set; }

        public ICollection<Assistent> Assistents { get; set; }
    }
}
