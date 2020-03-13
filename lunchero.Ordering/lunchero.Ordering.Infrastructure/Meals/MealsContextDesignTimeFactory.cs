using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace lunchero.Ordering.Infrastructure.Meals
{
    public class MealsContextDesignTimeFactory : IDesignTimeDbContextFactory<MealsContext>
    {
        public MealsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MealsContext>();
            optionsBuilder.UseSqlServer("Server=(local);Database=leckerito.lunchero;Trusted_Connection=true");
            return new MealsContext(optionsBuilder.Options);
        }
    }
}