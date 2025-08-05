using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public DateTime PublishedOn { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        //ilişkileri kur (navigation prop)
        public Post Post { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}