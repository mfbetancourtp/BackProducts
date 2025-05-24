using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts) { }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Product>()
              .ToTable("Products")
              .HasKey(p => p.Id);

            mb.Entity<Product>()
              .Property(p => p.CreatedAt)
              .HasDefaultValueSql("SYSUTCDATETIME()");
        }
    }
}
