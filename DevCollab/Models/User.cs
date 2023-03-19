﻿namespace DevCollab.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public ICollection<Post>? Posts { get; set; }


    }
}
