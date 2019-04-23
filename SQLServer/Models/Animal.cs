using System;

namespace SQLServer.Models
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public int Age { get; set; }
    }
}
