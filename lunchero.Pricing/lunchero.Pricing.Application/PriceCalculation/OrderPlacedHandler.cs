using System.Linq;
using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Orders.Messages.Events;
using lunchero.Pricing.Contracts.PriceCalculation.Messages.Events;
using lunchero.Pricing.Infrastructure.Meals;
using NServiceBus;
using NServiceBus.Logging;

namespace lunchero.Pricing.Application.PriceCalculation
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        public static ILog Log = LogManager.GetLogger<OrderPlacedHandler>();
        private readonly MealsContext mealsContext;

        public OrderPlacedHandler(MealsContext mealsContext)
        {
            this.mealsContext = mealsContext;
        }

        public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            Log.Info($"Pricing is handling order placed for meal id {message.MealId}");

            var meal = mealsContext.Meals.SingleOrDefault(m => m.MealId == message.MealId);

            if (meal == null)
                return;

            meal.Status = PriceStatus.PriceFixed;

            await context.Publish(new PricesCalculated() {
                MealId = meal.MealId
            });

            await mealsContext.SaveChangesAsync();
        }
    }
}