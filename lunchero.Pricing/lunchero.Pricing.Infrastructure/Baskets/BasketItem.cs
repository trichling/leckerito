using System;
using System.Collections.Generic;

namespace lunchero.Pricing.Infrastructure.Baskets
{
    public class BasketItem
    {

        public Guid Id { get; set; }
        
        public Guid BasketId { get; set; }

        public string ArticleNumber { get; set; }

        public int Quantity { get; set; }

        public decimal LinePrice { get; set; }
        
        public bool IsCheckedOut { get; set; }

    }
}