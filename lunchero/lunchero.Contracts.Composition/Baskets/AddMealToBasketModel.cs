using System;

namespace lunchero.Contracts.Composition.Baskets
{
    public class AddMealToBasketModel
    {
        public Guid MealId { get; set; }
        public Guid TableguestId { get; set; }
        public DateTime PickupOn { get; set; }
        public string ArticleNumber { get; set; }  
        public int Quantity { get; set; }  
        
    }
}