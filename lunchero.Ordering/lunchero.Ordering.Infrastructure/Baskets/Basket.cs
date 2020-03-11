using System;
using System.Collections.Generic;
using System.Linq;

namespace lunchero.Ordering.Infrastructure.Baskets
{
    public class Basket
    {

        public Basket()
        {
            Items = new List<BasketItem>();
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime? CheckedOutOn { get; set; }

        public List<BasketItem> Items { get; set; }

    }

    public class BasketItem
    {

        public string ArticleNumber { get; set; }

        public int Quantity { get; set; }

    }
}