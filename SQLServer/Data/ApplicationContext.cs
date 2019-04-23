using Microsoft.EntityFrameworkCore;
using SQLServer.Models;

namespace SQLServer.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupUser(modelBuilder);
            SetupAnimal(modelBuilder);
        }

        private void SetupUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(true);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Animals);
                //.WithOne(a => a.Id);
        }

        private void SetupAnimal(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Animal>()
                .Property(u => u.Age)
                .IsRequired();

            modelBuilder.Entity<Animal>()
                .Property(u => u.Kind)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Animal>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
