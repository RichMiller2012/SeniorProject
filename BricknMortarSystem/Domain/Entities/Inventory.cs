using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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


            items = new List<Item>();
            foreach (Item item in inventory.items)
            {
                this.items.Add(new Item(item));
            }          
        }
    }
}
