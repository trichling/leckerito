using System;

namespace lunchero.Ordering.Contracts.Baskets.Messages.Commands
{
    public class CheckOutBasket
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
    }
}