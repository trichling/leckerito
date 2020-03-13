using System;
using NServiceBus;

namespace lunchero.Pricing.Contracts.Baskets.Messages.Commands
{
    public class AddMealToBasket : IMessage
    {
        public Guid MealId { get; set; }
        public Guid TableguestId { get; set; }
        public DateTime PickupOn { get; set; }
        public string ArticleNumber { get; set; }  
        public int Quantity { get; set; }  
    }
}