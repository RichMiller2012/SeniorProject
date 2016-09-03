using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModels.SaleItem
{
    public class SaleItemViewAll
    {
        public virtual int saleItemId { get; set; }
        public virtual string name { get; set; }
        public virtual double salePrice { get; set; }
        public virtual int quantity { get; set; }

        public IList<string> barcodeViews { get; set; }
        public IList<string> partNoViews { get; set; }

        public SaleItemViewAll()
        {
            barcodeViews = new List<string>();
            partNoViews = new List<string>();
        }


    }
}