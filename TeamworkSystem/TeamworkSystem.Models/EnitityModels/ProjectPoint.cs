using System.Collections.Generic;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Models.EnitityModels
{
    public class ProjectPoint
    {
        public ProjectPoint()
        {
            this.Points = new HashSet<Point>();
        }
        public int Id { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Point> Points { get; set; }

        public virtual Assistent PointAssistent { get; set; }

        public virtual Trainer PointTrainer { get; set; }

    }
}
