using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace AudiophileBE.Entities
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int PostID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public string song_title { get; set; } = null!;
        public string album { get; set; } = null!;
        public string artist { get; set; } = null!;
        public int likes { get; set; }
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
