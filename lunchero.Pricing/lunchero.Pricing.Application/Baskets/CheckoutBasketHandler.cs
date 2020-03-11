using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using lunchero.Pricing.Contracts.Baskets.Messages.Commands;

namespace lunchero.Pricing.Application.Baskets
{
    public class CheckoutBasketHandler : IHandleMessages<CheckOutBasket>
    {
        public static ILog Log = LogManager.GetLogger<CheckoutBasketHandler>();

        public async Task Handle(CheckOutBasket message, IMessageHandlerContext context)
        {
            Log.Info($"CheckoutBasketHandler");
            
            await Task.CompletedTask;
        }
    }
}