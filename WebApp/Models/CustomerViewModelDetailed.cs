using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CustomerViewModelDetailed
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public double total { get; set; }
        public string phoneNumber { get; set; }

        public List<TransactionViewModelSimple> transactionViews;
        public List<SaleItemViewModel> saleItemViews;

        public CustomerViewModelDetailed()
        {
            transactionViews = new List<TransactionViewModelSimple>();
            saleItemViews = new List<SaleItemViewModel>();
        }
    }
}