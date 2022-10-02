using System.ComponentModel.DataAnnotations;

namespace AudiophileBE.Models
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

     
        public string? Email { get; set; }

        [Required]
        public string Password { get; set; } = null!;
       
    }
}
