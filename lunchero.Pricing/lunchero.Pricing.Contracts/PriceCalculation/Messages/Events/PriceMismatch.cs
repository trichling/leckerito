using System;

namespace lunchero.Pricing.Contracts.PriceCalculation.Messages.Events
{
    public class PriceMismatch
    {
        public Guid OrderId { get; set; }
    }
}