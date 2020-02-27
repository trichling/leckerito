using System;

namespace lunchero.Ordering.Contracts.Baskets.Messages.Commands
{
    public class AddArticleToBasket
    {
        public Guid UserId { get; set; }
        public string ArticleNumber { get; set; }  
        public int Quantity { get; set; }  

    }
}