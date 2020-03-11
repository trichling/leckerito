using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using lunchero.Pricing.Contracts.Baskets.Messages.Commands;
using lunchero.Pricing.Infrastructure.Baskets;
using System.Linq;

namespace lunchero.Pricing.Application.Baskets
{
    public class CheckoutBasketHandler : IHandleMessages<CheckOutBasket>
    {
        public static ILog Log = LogManager.GetLogger<CheckoutBasketHandler>();
        private readonly BasketsContext basketContext;

        public CheckoutBasketHandler(BasketsContext basketContext)
        {
            this.basketContext = basketContext;
        }

        public async Task Handle(CheckOutBasket message, IMessageHandlerContext context)
        {
            Log.Info($"Checking out basket {message.BasketId}");
            
            var items = this.basketContext.BasketItems.Where(i => i.BasketId == message.BasketId);

            foreach (var item in items)
            {
                item.IsCheckedOut = true;
            }

            await basketContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}