using System;

namespace lunchero.Ordering.Contracts.Baskets.Messages.Commands
{
    public class CheckoutAllMeals
    {
        public Guid TableguestId { get; set; }
    }
}