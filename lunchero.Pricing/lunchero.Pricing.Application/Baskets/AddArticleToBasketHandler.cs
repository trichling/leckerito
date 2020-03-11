using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using lunchero.Pricing.Contracts.Baskets.Messages.Commands;

namespace lunchero.Pricing.Application.Baskets
{
    public class AddArticleToBasketHandler : IHandleMessages<AddArticleToBasket>
    {
        public static ILog Log = LogManager.GetLogger<AddArticleToBasketHandler>();

        public async Task Handle(AddArticleToBasket message, IMessageHandlerContext context)
        {
            Log.Info($"Adding article {message.ArticleNumber} to basket calculating prices");
            
            await Task.CompletedTask;
        }
    }
}