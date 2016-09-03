using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iewModels.Inventory
{
    public class RecieveItem
    {
        public int inventoryId { get; set; }
        public int itemId { get; set; }
        public int quantity { get; set; }
    }
}