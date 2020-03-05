using System;

namespace lunchero.Warehouse.Contracts.Inventory.Messages.Events
{
    public class InsuficientStocks
    {
        public Guid OrderId { get; set; }
        
    }
}