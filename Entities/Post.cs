using System;
using System.Collections.Generic;

namespace AudiophileBE.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int PostId { get; set; }
        public int UserId { get; set; }
        public string SongTitle { get; set; } = null!;
        public string Album { get; set; } = null!;
        public string Artist { get; set; } = null!;
        public int Likes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
