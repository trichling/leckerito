using System;

namespace lunchero.Contracts.Composition.Baskets
{
    public class CheckoutBasketModel
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        
    }
}