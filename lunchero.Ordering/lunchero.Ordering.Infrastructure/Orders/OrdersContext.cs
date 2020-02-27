using Microsoft.EntityFrameworkCore;

namespace lunchero.Ordering.Infrastructure.Orders
{
    public class OrdersContext : DbContext
    {

        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.HasDefaultSchema("ordering");
            modelBuilder.Entity<Order>();
        }
    }
}