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
        public virtual Inventory inventory { get; set; }

        public virtual IList<Customer> customers { get; set; }
        public virtual IList<Transactions> transactions { get; set; }
    }
}
