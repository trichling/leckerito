using System;

namespace lunchero.Ordering.Contracts.Baskets.Messages.Commands
{
    public class AddMealToBasket
    {
        public Guid MealId { get; set; }
        public Guid TableguestId { get; set; }
        public DateTime PickupOn { get; set; }
        public string ArticleNumber { get; set; }  

    }
}