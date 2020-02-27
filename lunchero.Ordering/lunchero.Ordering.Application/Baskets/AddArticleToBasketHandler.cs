using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using lunchero.Ordering.Infrastructure.Baskets;
using NServiceBus;
using NServiceBus.Logging;
using System.Linq;
using System;

namespace lunchero.Ordering.Application.Baskets
{
    public class AddArticleToBasketHandler : IHandleMessages<AddArticleToBasket>
    {
        static ILog log = LogManager.GetLogger<AddArticleToBasketHandler>();
        private readonly BasketsContext basketsContext;

        public AddArticleToBasketHandler(BasketsContext context)
        {
            this.basketsContext = context;

        }

        public async Task Handle(AddArticleToBasket message, IMessageHandlerContext context)
        {
            var basket = basketsContext.Baskets.SingleOrDefault(b => b.UserId == message.UserId && b.CheckedOutOn == null);

            if (basket == null)
            {
                basket = new Basket() {
                    Id = Guid.NewGuid(),
                    UserId = message.UserId
                };

                basketsContext.Baskets.Add(basket);
            }

            basket.Items.Add(new BasketItem() 
            {  
                ArticleNumber = message.ArticleNumber,
                Quantity = message.Quantity
            });

            await basketsContext.SaveChangesAsync();
        }
    }
}