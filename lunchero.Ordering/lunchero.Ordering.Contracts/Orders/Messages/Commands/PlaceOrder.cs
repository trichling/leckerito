using System;

namespace lunchero.Ordering.Contracts.Orders.Messages.Commands
{
    public class PlaceOrder
    {
        public Guid MealId { get; set; }

        public Guid TableguestId { get; set; }

    }
}