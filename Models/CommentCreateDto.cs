using System.ComponentModel.DataAnnotations;

namespace AudiophileBE.Models
{
    public class CommentCreateDto
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string CommentBody { get; set; } = null!;
    }
}
