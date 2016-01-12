using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public virtual int customerId { get; set; }
        public virtual double total { get; set; }
        public virtual string phoneNumber { get; set; }
               
        public virtual Discount discount { get; set; }

        public virtual IList<Account> account { get; set; }
        public virtual IList<Transaction> transactions { get; set; }
        public virtual IList<Store> stores { get; set; }
        public virtual IList<Item> items { get; set; }     
    }         
}
