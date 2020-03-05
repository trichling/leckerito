using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Orders.Messages.Events;
using lunchero.Pricing.Contracts.PriceCalculation.Messages.Events;
using lunchero.Warehouse.Contracts.Inventory.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace lunchero.Delivery.Application.OrderRegistration
{
    public class RegisterOrderForDeliveryHandler : 
        IHandleMessages<OrderPlaced>,
        IHandleMessages<PricesCalculated>,
        IHandleMessages<PriceMismatch>,
        IHandleMessages<StocksReserved>,
        IHandleMessages<InsuficientStocks>
    {

        public static ILog Log = LogManager.GetLogger<RegisterOrderForDeliveryHandler>();

        public async Task Handle(OrderPlaced message, IMessageHandlerContext context)
        {
            Log.Info($"{nameof(RegisterOrderForDeliveryHandler)} is handling {message.GetType().Name} for order id {message.OrderId}");
            await Task.CompletedTask;
        }

        public async Task Handle(PricesCalculated message, IMessageHandlerContext context)
        {
            Log.Info($"{nameof(RegisterOrderForDeliveryHandler)} is handling {message.GetType().Name} for order id {message.OrderId}");
            await Task.CompletedTask;
        }

        public async Task Handle(PriceMismatch message, IMessageHandlerContext context)
        {
            Log.Info($"{nameof(RegisterOrderForDeliveryHandler)} is handling {message.GetType().Name} for order id {message.OrderId}");
            await Task.CompletedTask;
        }

        public async Task Handle(StocksReserved message, IMessageHandlerContext context)
        {
            Log.Info($"{nameof(RegisterOrderForDeliveryHandler)} is handling {message.GetType().Name} for order id {message.OrderId}");
            await Task.CompletedTask;
        }

        public async Task Handle(InsuficientStocks message, IMessageHandlerContext context)
        {
            Log.Info($"{nameof(RegisterOrderForDeliveryHandler)} is handling {message.GetType().Name} for order id {message.OrderId}");
            await Task.CompletedTask;
        }
    }
}