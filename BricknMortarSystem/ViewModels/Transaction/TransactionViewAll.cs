using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModels.Transaction
{
    public class TransactionViewAll
    {
        public virtual int transactionId { get; set; }
        public virtual double taxRate { get; set; }
        public virtual double totalAmount { get; set; }
        public virtual string transactionNumber { get; set; }
        public virtual string barcodeString { get; set; }
    }
}