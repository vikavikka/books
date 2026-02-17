using Microsoft.EntityFrameworkCore;
using books_api.Models;

namespace books_api.Data
{
    // AppDbContext apraksta mūsu datubāzi
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        // Norādam kādas tabulas būs mūsu datubāzē
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Author => Set<Author>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Like> Likes => Set<Like>();
        public DbSet<Review> Reviews => Set<Review>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base = parent klase
            base.OnModelCreating(modelBuilder);

            // izveidot pareizu sasaisti starp Posts un Users tabulu
            // izveidot FOREIGN KEY
            // -1 ja izdzēsīs lietotāju, automātiski izdzēsīsies posti
            // -2 PostId lauks var būt aizpildīts tikai ar eksistējoša User id

            // Norādam Author -> Books relāciju (One-To-Many)
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Norādam User -> Like relāciju (One-To-Many)
            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Norādam Book -> Like relāciju (One-To-Many)
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Books)
                .WithMany(b => b.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Izdaram tā, lai likes neduplicētos
            modelBuilder.Entity<Like>()
                .HasIndex(l => new { l.UserId, l.BookId })
                .IsUnique();

            // Norādam User -> Review relāciju (One-To-Many)
            modelBuilder.Entity<Reviews>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Norādam Books -> Reviews relāciju (One-To-Many)
            modelBuilder.Entity<Reviews>()
                .HasOne(r => r.Books)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
