using System;

namespace lunchero.Ordering.Contracts.Baskets.Models
{
    public class AddArticleToBasketModel
    {

        public Guid PickupId { get; set; }
        public string ArticleNumber { get; set; }  
        public int Quantity { get; set; }  
    }
}