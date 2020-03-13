using System;

namespace lunchero.Ordering.Contracts.Orders.Messages.Events
{
    public class OrderPlaced
    {
        public Guid MealId { get; set; }

        public Guid TableguestId { get; set; }

    }
}