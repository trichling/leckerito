using System;

namespace lunchero.Pricing.Contracts.PriceCalculation.Messages.Events
{
    public class PricesCalculated
    {
        public Guid OrderId { get; set; }
        
    }
}