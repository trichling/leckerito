using System;
using System.Threading.Tasks;
using lunchero.Ordering.Contracts.Orders.Messages.Commands;
using lunchero.Ordering.Contracts.Orders.Messages.Events;
using lunchero.Ordering.Infrastructure.Orders;
using NServiceBus;

namespace lunchero.Ordering.Application.Orders
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        private readonly OrdersContext ordersContext;

        public PlaceOrderHandler(OrdersContext ordersContext)
        {
            this.ordersContext = ordersContext;

        }

        public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
        {
            var orderId = Guid.NewGuid();

            ordersContext.Orders.Add(new Order()
            {
                Id = orderId,
                UserId = message.UserId,
                OrderedAt = DateTime.Now,
                PickupId = message.PickupId,
                ArticleNumber = message.ArticleNumber,
                Quantity = message.Quantity,
                Status = OrderStatus.Pending
            });

            await context.Publish(new OrderPlaced(){
                OrderId = orderId,
                UserId = message.UserId,
                PickupId = message.PickupId,
                ArticleNumber = message.ArticleNumber,
                Quantity = message.Quantity
            }).ConfigureAwait(false);

            await ordersContext.SaveChangesAsync();
        }
    }
}