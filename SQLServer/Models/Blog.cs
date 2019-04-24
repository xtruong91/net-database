using System.Collections.Generic;

namespace SQLServer.Models
{
    public class Blog
    {
        public Blog()
        {
            Post = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Url { get; set; }

        public ICollection<Post> Post { get; set; }
    }
}
