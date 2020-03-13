using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using System.Linq;
using System;
using lunchero.Ordering.Infrastructure.Meals;

namespace lunchero.Ordering.Application.Baskets
{
    public class AddMealToBasketHandler : IHandleMessages<AddMealToBasket>
    {
        static ILog log = LogManager.GetLogger<AddMealToBasketHandler>();
        private readonly MealsContext mealsContext;

        public AddMealToBasketHandler(MealsContext mealsContext)
        {
            this.mealsContext = mealsContext;
        }

        public async Task Handle(AddMealToBasket message, IMessageHandlerContext context)
        {
            var meal = new Meal()
            {
                MealId = message.MealId,
                TableguestId = message.TableguestId,
                ArticleNumber = message.ArticleNumber,
                PickupOn = message.PickupOn,
                Status = MealStatus.InBasket
            };

            mealsContext.Meals.Add(meal);

            await mealsContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}