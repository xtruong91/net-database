using Microsoft.EntityFrameworkCore;
using SQLite.Models;

namespace SQLite.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options)
        {
        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
