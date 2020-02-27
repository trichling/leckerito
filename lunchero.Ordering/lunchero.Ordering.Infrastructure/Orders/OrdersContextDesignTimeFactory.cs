using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace lunchero.Ordering.Infrastructure.Orders
{
    public class OrdersContextDesignTimeFactory : IDesignTimeDbContextFactory<OrdersContext>
    {
        public OrdersContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrdersContext>();
            optionsBuilder.UseSqlServer("Server=(local);Database=leckerito.lunchero;Trusted_Connection=true");
            return new OrdersContext(optionsBuilder.Options);
        }
    }
}