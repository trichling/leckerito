using System;
using System.Linq;
using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Baskets.Messages.Commands;
using lunchero.Ordering.Contracts.Orders.Messages.Commands;
using lunchero.Ordering.Infrastructure.Baskets;
using NServiceBus;

namespace lunchero.Ordering.Application.Baskets
{
    public class CheckOutBasketHandler : IHandleMessages<CheckOutBasket>
    {
        private readonly BasketsContext basketContext;
        public CheckOutBasketHandler(BasketsContext basketContext)
        {
            this.basketContext = basketContext;
        }

        public async Task Handle(CheckOutBasket message, IMessageHandlerContext context)
        {
            var basket = basketContext.Baskets.SingleOrDefault(b => b.UserId == message.UserId && b.CheckedOutOn == null);

            if (basket == null)
            {
                // handle error state!
                return;
            }

            basket.CheckedOutOn = DateTime.Now;

            foreach (var order in basket.Items)
            {
                await context.Send(new PlaceOrder()
                {
                    Id = Guid.NewGuid(),
                    UserId = message.UserId,
                    BasketId = basket.Id,
                    PickupId = order.PickupId,
                    ArticleNumber = order.ArticleNumber,
                    Quantity = order.Quantity
                }).ConfigureAwait(false);
            }

            await basketContext.SaveChangesAsync();
        }
    }
}