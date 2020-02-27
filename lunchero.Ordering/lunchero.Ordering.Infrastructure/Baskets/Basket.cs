using System;
using System.Collections.Generic;

namespace lunchero.Ordering.Infrastructure.Baskets
{
    public class Basket
    {

        public Guid Id { get; private set; }

        public Guid UserId { get; set; }

        public DateTime? CheckedOutOn { get; set; }

        public IEnumerable<BasketItem> Items { get; set; }

    }

    public class BasketItem
    {
        public string ArticleNumber { get; set; }
        public int Quantity { get; set; }

    }
}