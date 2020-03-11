using System;

namespace lunchero.Contracts.Composition.Baskets
{
    public class AddArticleToBasketModel
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public DateTime PickupAt { get; set; }
        public string ArticleNumber { get; set; }  
        public int Quantity { get; set; }  
        
    }
}