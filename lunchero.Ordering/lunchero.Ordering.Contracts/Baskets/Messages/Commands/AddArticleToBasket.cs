using System;

namespace lunchero.Ordering.Contracts.Baskets.Messages.Commands
{
    public class AddArticleToBasket
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public Guid PickupId { get; set; }
        public string ArticleNumber { get; set; }  
        public int Quantity { get; set; }  

    }
}