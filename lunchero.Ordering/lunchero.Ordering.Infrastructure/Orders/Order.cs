using System;

namespace lunchero.Ordering.Infrastructure.Orders
{
    public class Order
    {

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid PickupId { get; set; }

        public string ArticleNumber { get; set; }

        public int Quantity { get; set; }

        public DateTime OrderedAt { get; set; }

        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {

        Pending = 0,

        Accepted = 1,
         
        Rejected = 2

    }
}