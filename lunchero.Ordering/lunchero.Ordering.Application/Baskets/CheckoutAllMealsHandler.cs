using System;
using System.Linq;
using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using lunchero.Ordering.Contracts.Orders.Messages.Commands;
using lunchero.Ordering.Infrastructure.Meals;
using NServiceBus;

namespace lunchero.Ordering.Application.Baskets
{
    public class CheckoutAllMealsHandler : IHandleMessages<CheckoutAllMeals>
    {
        private readonly MealsContext mealsContext;

        public CheckoutAllMealsHandler(MealsContext mealsContext)
        {
            this.mealsContext = mealsContext;
        }

        public async Task Handle(CheckoutAllMeals message, IMessageHandlerContext context)
        {
            var mealsInBasket = mealsContext.Meals.Where(m => m.TableguestId == message.TableguestId && m.Status == MealStatus.InBasket);

            foreach (var meal in mealsInBasket)
            {
                await context.Send(new PlaceOrder()
                {
                    MealId = meal.MealId,
                    TableguestId = meal.TableguestId
                }).ConfigureAwait(false);
            }
        }
    }
}