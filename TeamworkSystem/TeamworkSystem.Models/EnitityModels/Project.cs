using System.Collections.Generic;

namespace TeamworkSystem.Models.EnitityModels
{
    public class Project
    {
        public Project()
        {
            this.Points = new HashSet<ProjectPoint>();
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual Course Course { get; set; }

        public virtual Team Team { get; set; }

        public string Repository { get; set; }

        public string LiveDemo { get; set; }

        public bool IsActive { get; set; }

        public bool IsPublic { get; set; }

        public int Vote { get; set; }

        public decimal Grade { get; set; }

        public virtual Photo ProjectPicture { get; set; }

        public virtual Album Photos { get; set; }

        public virtual ICollection<ProjectPoint> Points { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
