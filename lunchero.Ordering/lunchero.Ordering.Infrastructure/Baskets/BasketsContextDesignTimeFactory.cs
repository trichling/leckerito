using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace lunchero.Ordering.Infrastructure.Baskets
{
    public class BasketsContextDesignTimeFactory : IDesignTimeDbContextFactory<BasketsContext>
    {
        public BasketsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BasketsContext>();
            optionsBuilder.UseSqlServer("Server=(local);Database=leckerito.lunchero.OrderingDb;Trusted_Connection=true");
            return new BasketsContext(optionsBuilder.Options);
        }
    }
}