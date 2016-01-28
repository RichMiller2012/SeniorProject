﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SaleItem
    {
        public virtual int saleItemId { get; set; }
        public virtual string name { get; set; }
        public virtual double salePrice { get; set; }
        public virtual int quantity { get; set; }

        public virtual Transactions transaction { get; set; }

        public virtual IList<Barcode> barcodes { get; set; }
        public virtual IList<PartNo> partNos { get; set; }

        //protected constructor for nHibernate use
        protected SaleItem()
        {
        }
        //depends on existing item
        public SaleItem(Item item)
        {
            name = item.name;
            barcodes = item.barcodes;
            partNos = item.partNos;
        }
    }
}
