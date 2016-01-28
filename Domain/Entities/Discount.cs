using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
