using System;
using NServiceBus;
using lunchero.Pricing.Contracts.Baskets;

namespace lunchero.Pricing.Application.Baskets
{
    public class AddArticleToBasketHandler : IHandleMessages<AddArticleToBasket>
    {
        public static ILog Log = LogManager.GetLogger<OrderPlacedHandler>();

        public async Task Handle(AddArticleToBasket message, IMessageHandlerContext context)
        {
            Log.Info($"Adding article {message.ArticleId} to basket calculating prices");
            
            await Task.CompletedTask;
        }
    }
}