using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Orders.Messages.Commands;
using NServiceBus;

namespace lunchero.Ordering.Application.Orders
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            // store in database

            //await context.Publish()

            await Task.CompletedTask;
        }
    }
}