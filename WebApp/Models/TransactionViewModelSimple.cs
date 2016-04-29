using System;
using System.Collections.Generic;
using Domain.Entities;


namespace WebApp.Models
{
    public class TransactionViewModelSimple
    {
        public int transactionId { get; set; }
        public double taxRate { get; set; }
        public double totalAmount { get; set; }
        public string transactionNumber { get; set; }

        public int customerId { get; set; }
        public int storeId { get; set; }
    }
}