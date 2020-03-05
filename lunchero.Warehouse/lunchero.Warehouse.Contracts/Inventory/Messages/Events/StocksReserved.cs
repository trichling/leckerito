using System;

namespace lunchero.Warehouse.Contracts.Inventory.Messages.Events
{
    public class StocksReserved
    {
        
        public Guid OrderId { get; set; }

    }
}