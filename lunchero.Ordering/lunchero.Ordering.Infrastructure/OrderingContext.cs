using Microsoft.EntityFrameworkCore;

namespace lunchero.Ordering.Infrastructure
{
    public class OrderingContext : DbContext
    {
        
        public OrderingContext(DbContextOptions<OrderingContext> options)
            : base(options)
        {
            
        }

        public DbSet<object> MyObjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

        }


    }
}