using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item
    {
        public virtual int itemId { get; set; }
        public virtual string  name { get; set; }
        public virtual double retailPrice { get; set; }
        public virtual double wholesalePrice { get; set; }
        public virtual int quantity { get; set; }
                
        public virtual IList<Barcode> barcodes { get; set; }
        public virtual IList<PartNo> partNos { get; set; }
        public virtual IList<Transactions> transactions { get; set; }
        public virtual IList<Customer> customers { get; set; }
        public virtual IList<Dates> saleDate { get; set; }
        public virtual IList<Dates> inDate { get; set; }
                
        public virtual Inventory inventory { get; set; }

    }
}
