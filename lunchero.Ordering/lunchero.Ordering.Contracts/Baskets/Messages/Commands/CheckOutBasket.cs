using System;

namespace lunchero.Ordering.Contracts.Baskets.Messages.Commands
{
    public class CheckOutBasket
    {
        public Guid UserId { get; set; }
    }
}