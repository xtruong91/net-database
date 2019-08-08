using ReactApp.Models;
using System.Collections.Generic;

namespace ReactApp.Mocker
{
    public class Pack
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Story> Stories { get; set; } = new List<Story>();
    }
}
