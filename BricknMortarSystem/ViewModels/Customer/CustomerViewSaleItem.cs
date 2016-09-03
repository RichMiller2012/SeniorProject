using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.SaleItem;

namespace ViewModels.Customer
{
    public class CustomerViewSaleItem
    {
        public int customerId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public double total { get; set; }
        public string phoneNumber { get; set; }

        public IList<SaleItemViewAll> saleItemViewAlls { get; set; }

        public CustomerViewSaleItem()
        {
            saleItemViewAlls = new List<SaleItemViewAll>();
        }
    }
}