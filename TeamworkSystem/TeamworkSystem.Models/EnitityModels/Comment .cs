namespace TeamworkSystem.Models.EnitityModels
{
    using System;

    using TeamworkSystem.Models.EnitityModels.Users;

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PostedDate { get; set; }

        public virtual Student Author { get; set; }
    }
}
