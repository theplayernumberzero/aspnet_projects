using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string? Text { get; set; }

        //ilişkileri kur (navigation prop)
        public List<Post> Tags { get; set; } = new List<Post>();
    }
}