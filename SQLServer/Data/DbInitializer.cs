using SQLServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer.Data
{
    public class DbInitializer
    {
        public static void Initialize(BloggingContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "email@email.com",
                Name = "User1",
                Password = "password",
                Role = Role.Admin,
                Animals = new List<Animal>
                {
                    new Animal
                    {
                        Id = Guid.NewGuid(),
                        Age = 5,
                        Name = "animal",
                        Kind = "dog"
                    }
                }
            };

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
