using System;

namespace lunchero.Pricing.Contracts.PriceCalculation.Messages.Events
{
    public class PricesCalculated
    {
        public Guid MealId { get; set; }
        
    }
}