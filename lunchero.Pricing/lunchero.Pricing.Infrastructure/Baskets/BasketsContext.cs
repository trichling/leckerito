using Microsoft.EntityFrameworkCore;

namespace lunchero.Pricing.Infrastructure.Baskets
{
    public class BasketsContext : DbContext
    {
        
        public BasketsContext(DbContextOptions<BasketsContext> options) : base(options)
        {
            
        }

        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("pricing");
            modelBuilder.Entity<BasketItem>();
        }

    }
}