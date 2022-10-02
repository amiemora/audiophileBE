using System.ComponentModel.DataAnnotations;

namespace AudiophileBE.Models
{
    public class PostCreateDto
    {
        [Required]
        public int UserId { get; set; }
        public string SongTitle { get; set; } = null!;
        public string Album { get; set; } = null!;
        public string Artist { get; set; } = null!;
    }
}
