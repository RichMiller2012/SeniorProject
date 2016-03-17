using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inventory
    {
        public virtual int inventoryId { get; set; }
        public virtual string name { get; set; }
        public virtual Store store { get; set; }
        public virtual IList<Item> items { get; set; }

        public Inventory()
        {
            items = new List<Item>();
        }

        //copy constructor
        public Inventory(Inventory inventory)
        {
            this.inventoryId = inventory.inventoryId;
            this.name = inventory.name;
            this.store = inventory.store;
            this.items = inventory.items;
        }
    }
}
