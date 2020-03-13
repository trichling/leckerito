using System;
using System.Linq;
using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Orders.Messages.Commands;
using lunchero.Ordering.Contracts.Orders.Messages.Events;
using lunchero.Ordering.Infrastructure.Meals;
using NServiceBus;

namespace lunchero.Ordering.Application.Orders
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        private readonly MealsContext mealsContext;

        public PlaceOrderHandler(MealsContext mealsContext)
        {
            this.mealsContext = mealsContext;
        }

        public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            var meal = mealsContext.Meals.SingleOrDefault(m => m.MealId == message.MealId);

            if (meal == null)
                return;

            await context.Publish(new OrderPlaced()
            {
               MealId = meal.MealId,
               TableguestId = meal.TableguestId
            }).ConfigureAwait(false);

            meal.Status = MealStatus.OrderPlaced;

            await mealsContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}