using System.Collections.Generic;

namespace ReactApp.Models
{
    public class User : IEntityBase
    {
        public User()
        {
            Stories = new List<Story>();
        }
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Story> Stories { get; set; }
    }
}