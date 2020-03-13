using System;

namespace lunchero.Ordering.Infrastructure.Meals
{
    public class Meal
    {
        public Guid MealId { get; set; }
        public Guid TableguestId { get; set; }
        public string ArticleNumber { get; set; }
        public DateTime PickupOn { get; set; }
        public MealStatus Status { get; set; }
    }

    public enum MealStatus
    {
        InBasket = 0,
        OrderPlaced = 1
    }
}