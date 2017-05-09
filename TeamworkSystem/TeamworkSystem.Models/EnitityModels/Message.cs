namespace TeamworkSystem.Models.EnitityModels
{
    using System;

    using TeamworkSystem.Models.EnitityModels.Users;

    public class Message
    {
        public int Id { get; set; }

        public Student Sender { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
