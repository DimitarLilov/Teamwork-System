namespace TeamworkSystem.Models.EnitityModels
{
    using System.Collections.Generic;

    public class Album
    {
        public Album()
        {
            this.Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
