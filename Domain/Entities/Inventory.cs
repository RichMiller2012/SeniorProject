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
        public virtual Store store { get; set; }

        public virtual IList<Item> items { get; set; }      
    }
}
