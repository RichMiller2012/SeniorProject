﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Transactions
    {
        public virtual int transactionId { get; set; }
        public virtual double taxRate { get; set; }
        public virtual double totalAmount { get; set; }
        public virtual string transactionNumber { get; set; }
        public virtual string barcodeString { get; set; }
           
        public virtual Customer customer { get; set; }
        public virtual Store store { get; set; }

        public virtual DateTime date { get; set; }            
        public virtual IList<SaleItem> saleItems { get; set; }

        public Transactions()
        {
            saleItems = new List<SaleItem>();
            date = DateTime.Now;
        }

        //copy constructor
        public Transactions(Transactions trans)
        {
            this.transactionId = trans.transactionId;
            this.taxRate = trans.taxRate;
            this.totalAmount = trans.totalAmount;
            this.transactionNumber = trans.transactionNumber;
            this.barcodeString = trans.barcodeString;
            this.customer = trans.customer;
            this.store = trans.store;
            this.date = trans.date;
            this.saleItems = trans.saleItems;
        }
    }
}