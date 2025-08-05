using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }

        //ilişkileri kur (navigation prop)
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}