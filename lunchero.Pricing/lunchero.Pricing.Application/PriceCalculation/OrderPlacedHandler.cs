using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Orders.Messages.Events;
using lunchero.Pricing.Contracts.PriceCalculation.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace lunchero.Pricing.Application.PriceCalculation
{
    public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
    {
        public static ILog Log = LogManager.GetLogger<OrderPlacedHandler>();

        public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            Log.Info($"Pricing is handling order placed for order id {message.OrderId}");
            await context.Publish(new PricesCalculated() {
                OrderId = message.OrderId
            });
        }
    }
}