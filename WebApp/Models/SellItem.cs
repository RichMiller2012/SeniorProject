using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class SellItem
    {
        public int customerId { get; set; }
        public int inventoryId { get; set; }
        public List<SaleItemData> saleItems { get; set; }
    };

    public struct SaleItemData
    {
        public int itemId;
        public int quantity;
    };
}