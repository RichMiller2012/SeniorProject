using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.Discount;
using ViewModels.Transaction;

namespace ViewModels.Customer
{
    public class CustomerDetailView
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public double total { get; set; }
        public string phoneNumber { get; set; }

        public DiscountSimpleView discountSimpleView { get; set; }

        public IList<TransactionViewAll> transactionsViewAlls { get; set; }

        public CustomerDetailView()
        {
            transactionsViewAlls = new List<TransactionViewAll>();
        }

    }
}