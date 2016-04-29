using System;
using System.Collections.Generic;
using Domain.Entities;

namespace WebApp.Models
{
    public class TransactionViewModelDetailed
    {
        public int transactionId { get; set; }
        public double taxRate { get; set; }
        public double totalAmount { get; set; }
        public string transactionNumber { get; set; }

        public CustomerViewModelSimple customerViewModel { get; set; }
        public int storeId { get; set; }
        public IList<SaleItemViewModel> saleItemViewModels { get; set; }

        public TransactionViewModelDetailed()
        {
            saleItemViewModels = new List<SaleItemViewModel>();
        }
    }
}