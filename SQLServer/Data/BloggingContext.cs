using Microsoft.EntityFrameworkCore;
using SQLServer.Models;

namespace SQLServer.Data
{
    public class BloggingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }

        public BloggingContext(DbContextOptions<BloggingContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetupUser(modelBuilder);
            SetupAnimal(modelBuilder);
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Post)
                    .HasForeignKey(d => d.BlogId);
            });
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
