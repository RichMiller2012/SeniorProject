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
        public virtual string description { get; set; }
        public virtual double retailPrice { get; set; }
        public virtual double wholesalePrice { get; set; }
        public virtual int quantity { get; set; }
        
                
        public virtual IList<Barcode> barcodes { get; set; }
        public virtual IList<PartNo> partNos { get; set; }
        public virtual IList<Dates> inDate { get; set; }
                
        public virtual Inventory inventory { get; set; }

        public Item()
        {
            barcodes = new List<Barcode>();
            partNos = new List<PartNo>();
            inDate = new List<Dates>();
        }
    }
}
