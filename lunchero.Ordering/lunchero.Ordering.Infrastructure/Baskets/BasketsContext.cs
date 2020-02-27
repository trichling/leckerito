using Microsoft.EntityFrameworkCore;

namespace lunchero.Ordering.Infrastructure.Baskets
{
    public class BasketsContext : DbContext
    {
        
        public BasketsContext(DbContextOptions<BasketsContext> options) : base(options)
        {
            
        }

        public DbSet<Basket> Baskets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ordering");
            modelBuilder.Entity<Basket>().OwnsMany(b => b.Items);
        }

    }
}