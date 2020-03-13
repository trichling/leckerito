using Microsoft.EntityFrameworkCore;

namespace lunchero.Pricing.Infrastructure.Meals
{
    public class MealsContext : DbContext
    {
        
        public MealsContext(DbContextOptions<MealsContext> options)
            : base (options)
        {
            
        }

        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.HasDefaultSchema("pricing");
            modelBuilder.Entity<Meal>();
        }

    }
}