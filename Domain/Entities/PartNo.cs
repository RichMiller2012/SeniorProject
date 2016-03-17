using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PartNo
    {
        public virtual int partNoId { get; set; }
        public virtual string number { get; set; }
        public virtual Item item { get; set; }
        public virtual SaleItem saleItem { get; set; }

        public PartNo()
        {
        }

        //copy constructor
        public PartNo(PartNo partNo)
        {
            this.partNoId = partNo.partNoId;
            this.number = partNo.number;
            this.item = partNo.item;
            this.saleItem = partNo.saleItem;
        }
    }
}
