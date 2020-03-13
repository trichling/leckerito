using System;

namespace lunchero.Pricing.Infrastructure.Meals
{
    public class Meal
    {
        public Guid MealId { get; set; }
        public Guid TableguestId { get; set; }
        public DateTime PickupOn { get; set; }
        public string ArticleNumber { get; set; }  
        public int Quantity { get; set; } 
        public decimal Price { get; set; }  
        public PriceStatus Status { get; set; }
    }

    public enum PriceStatus
    {

        PriceOpen = 0,
        PriceFixed = 1

    }
}