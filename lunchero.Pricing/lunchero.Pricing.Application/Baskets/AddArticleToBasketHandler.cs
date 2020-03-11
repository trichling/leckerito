using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using lunchero.Pricing.Contracts.Baskets.Messages.Commands;
using lunchero.Pricing.Infrastructure.Baskets;

namespace lunchero.Pricing.Application.Baskets
{
    public class AddArticleToBasketHandler : IHandleMessages<AddArticleToBasket>
    {
        public static ILog Log = LogManager.GetLogger<AddArticleToBasketHandler>();
        private readonly BasketsContext basketContext;

        public AddArticleToBasketHandler(BasketsContext basketContext)
        {
            this.basketContext = basketContext;
        }

        public async Task Handle(AddArticleToBasket message, IMessageHandlerContext context)
        {
            Log.Info($"Adding article {message.ArticleNumber} to basket calculating prices");

            var basketItem = new BasketItem()
            {
                BasketId = message.BasketId,
                ArticleNumber = message.ArticleNumber,
                Quantity = message.Quantity,
                LinePrice = message.Quantity * 1.1M
            };

            this.basketContext.BasketItems.Add(basketItem);

            await this.basketContext.SaveChangesAsync().ConfigureAwait(false);            
        }
    }
}