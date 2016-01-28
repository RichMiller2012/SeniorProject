using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transactions
    {
        public virtual int transactionId { get; set; }
        public virtual double taxRate { get; set; }
        public virtual double totalAmount { get; set; }
        public virtual string transactionNumber { get; set; }
                
        public virtual Customer customer { get; set; }
        public virtual Store store { get; set; }
        public virtual DateTime date { get; set; }
                
        public virtual IList<SaleItem> saleItems { get; set; }

        public Transactions()
        {
            saleItems = new List<SaleItem>();
        }
    }
}
