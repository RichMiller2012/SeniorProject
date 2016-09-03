using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.Item;

namespace ViewModels.Inventory
{
    public class InventoryDetailView
    {
        public int inventoryId { get; set; }
        public string name { get; set; }

        public List<ItemViewAll> itemViewAlls { get; set; }

        public InventoryDetailView()
        {
            itemViewAlls = new List<ItemViewAll>();
        }
    }
}