using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<UrlMapping> UrlMappings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure the Id property as an identity column for PostgreSQL
            modelBuilder.Entity<UrlMapping>()
                .Property(u => u.Id)
                .UseIdentityAlwaysColumn();

            // Configure the LongUrl property
            modelBuilder.Entity<UrlMapping>()
                .Property(u => u.LongUrl)
                .IsRequired()
                .HasMaxLength(2048); // Adjust the max length as needed

            // Configure the ShortCode property
            modelBuilder.Entity<UrlMapping>()
                .Property(u => u.ShortCode)
                .IsRequired()
                .HasMaxLength(255); // Adjust the max length as needed

            modelBuilder.Entity<UrlMapping>()
                .HasAlternateKey(u => u.ShortCode); // Define it as an alternate key to enforce uniqueness

            // Configure the CreatedAt property
            modelBuilder.Entity<UrlMapping>()
                .Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()"); // Set a default value of the current timestamp

            // Other configurations...

            // Example of other configurations for additional properties if needed:
            // modelBuilder.Entity<UrlMapping>()
            //     .Property(u => u.SomeOtherProperty)
            //     .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
