using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Discount
    {
        public virtual int discountId { get; set; }
        public virtual double percentRate { get; set; }
        public virtual double amount { get; set; }
        public virtual IList<Customer> customers { get; set; }

        public virtual Store store { get; set; }

        public Discount()
        {
            customers = new List<Customer>();
        }

        //copy constructor
        public Discount(Discount discount)
        {
            this.discountId = discount.discountId;
            this.percentRate = discount.percentRate;
            this.amount = discount.amount;
            this.customers = discount.customers;
            this.store = discount.store;
        }
    }
}
