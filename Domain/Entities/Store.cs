using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Store
    {
        public virtual int storeId { get; set; }
        public virtual string name { get; set; }
        public virtual double taxRate { get; set; }
        
        public virtual IList<Inventory> inventories { get; set; }
        public virtual IList<Customer> customers { get; set; }
        public virtual IList<Transactions> transactions { get; set; }
        public virtual IList<Discount> discounts { get; set; }

        public Store()
        {
            customers = new List<Customer>();
            transactions = new List<Transactions>();
            inventories = new List<Inventory>();
            discounts = new List<Discount>();
        }
    }
}
