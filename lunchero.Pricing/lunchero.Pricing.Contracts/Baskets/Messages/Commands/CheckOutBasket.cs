using System;

namespace lunchero.Pricing.Contracts.Baskets.Messages.Commands
{
    public class CheckOutBasket
    {
        public Guid BasketId { get; set; }
    }
}