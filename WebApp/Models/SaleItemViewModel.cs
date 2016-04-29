using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class SaleItemViewModel
    {
        public virtual int saleItemId { get; set; }
        public virtual string name { get; set; }
        public virtual double salePrice { get; set; }
        public virtual int quantity { get; set; }

        public int transactionId { get; set; }
    }
}