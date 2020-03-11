using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace lunchero.Pricing.Infrastructure.Baskets
{
    public class BasketsContextDesignTimeFactory : IDesignTimeDbContextFactory<BasketsContext>
    {
        public BasketsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BasketsContext>();
            optionsBuilder.UseSqlServer("Server=(local);Database=leckerito.lunchero;Trusted_Connection=true");
            return new BasketsContext(optionsBuilder.Options);
        }
    }
}