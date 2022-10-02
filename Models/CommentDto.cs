namespace AudiophileBE.Models
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string CommentBody { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public int? Likes { get; set; }
    }
}
