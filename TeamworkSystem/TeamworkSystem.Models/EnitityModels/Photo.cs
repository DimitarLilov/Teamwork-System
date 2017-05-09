namespace TeamworkSystem.Models.EnitityModels
{
    using System.Collections.Generic;

    using TeamworkSystem.Models.EnitityModels.Users;

    public class Photo
    {
        public Photo()
        {
            this.CoursePhotos = new HashSet<Course>();
            this.ProjectPhotos = new HashSet<Project>();
            this.UserPhotos = new HashSet<ApplicationUser>();
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        public string UrlPthoto { get; set; }

        public virtual ICollection<ApplicationUser> UserPhotos { get; set; }

        public virtual ICollection<Project> ProjectPhotos { get; set; }

        public virtual ICollection<Course> CoursePhotos { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
