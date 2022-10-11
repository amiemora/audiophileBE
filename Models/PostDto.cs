namespace AudiophileBE.Models
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string song_title { get; set; } = null!;
        public string Album { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public int Likes { get; set; }
    }
}
