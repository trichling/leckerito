using System;

namespace lunchero.Ordering.Contracts.Orders.Messages.Commands
{
    public class PlaceOrder
    {
        public Guid Id { get; set; }

        public Guid BasketId { get; set; }
        
        public Guid UserId { get; set; }

        public Guid PickupId { get; set; }

        public string ArticleNumber { get; set; }

        public int Quantity { get; set; }
    }
}