using System;

namespace lunchero.Ordering.Contracts.Orders.Messages.Events
{
    public class OrderPlaced
    {
        public Guid OrderId { get; set; }

        public Guid PickupId { get; set; }
        
        public Guid UserId { get; set; }

        public string ArticleNumber { get; set; }

        public int Quantity { get; set; }
    }
}