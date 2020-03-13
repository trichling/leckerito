using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using lunchero.Pricing.Contracts.Baskets.Messages.Commands;
using lunchero.Pricing.Infrastructure.Meals;

namespace lunchero.Pricing.Application.Baskets
{
    public class AddMealToBasketHandler : IHandleMessages<AddMealToBasket>
    {
        public static ILog Log = LogManager.GetLogger<AddMealToBasketHandler>();
        private readonly MealsContext mealsContext;

        public AddMealToBasketHandler(MealsContext mealsContext)
        {
            this.mealsContext = mealsContext;
        }

        public async Task Handle(AddMealToBasket message, IMessageHandlerContext context)
        {
            Log.Info($"Adding article {message.ArticleNumber} to basket calculating prices");

            var meal = new Meal()
            {
                MealId = message.MealId,
                TableguestId = message.TableguestId,
                PickupOn = message.PickupOn,
                ArticleNumber = message.ArticleNumber,
                Quantity = message.Quantity,
                Price = message.Quantity * (1.1M + message.Quantity / 10),
                Status = PriceStatus.PriceOpen
            };

            mealsContext.Meals.Add(meal);

            await mealsContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}