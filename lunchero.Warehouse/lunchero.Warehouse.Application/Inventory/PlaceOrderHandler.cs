using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Orders.Messages.Events;
using lunchero.Warehouse.Contracts.Inventory.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace lunchero.Warehouse.Application.Inventory
{
    public class PlaceOrderHandler : IHandleMessages<OrderPlaced>
    {
        public static ILog Log = LogManager.GetLogger<PlaceOrderHandler>();

        public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            Log.Info($"Warehouse is handling OrderPlaced for oder id {message.OrderId}");

            await context.Publish(new StocksReserved()
            {
                OrderId = message.OrderId
            });
        }
    }
}