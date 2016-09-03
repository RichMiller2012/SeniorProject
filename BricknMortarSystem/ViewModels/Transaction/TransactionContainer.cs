using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.Customer;
using ViewModels.SaleItem;

namespace ViewModels.Transaction
{
    public class TransactionContainer
    {
        //inbound properties
        public int customerId { get; set; }
        public int storeId { get; set; }
        public List<ItemQuantityGroup> saleItems { get; set; }

        //outbound display
        public string storeName { get; set; }
        public CustomerViewAll customer { get; set; }
        public string transactionNumber { get; set; }
        public List<SaleItemViewAll> saleItemViews { get; set; }
        public double total { get; set; }

        
        public TransactionContainer()
        {
            saleItemViews = new List<SaleItemViewAll>();
            customer = new CustomerViewAll();
            saleItems = new List<ItemQuantityGroup>();
        }

        public class ItemQuantityGroup
        {
            public int itemId { get; set; }
            public int quantity { get; set; }
        }
    }
}