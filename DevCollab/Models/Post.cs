namespace DevCollab.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Message { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public User? user { get; set; }

    }

}
