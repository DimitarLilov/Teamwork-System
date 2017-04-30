using System;
using TeamworkSystem.Models.EnitityModels.Users;

namespace TeamworkSystem.Models.EnitityModels
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PostedDate { get; set; }

        public virtual Student Author { get; set; }

    }
}
