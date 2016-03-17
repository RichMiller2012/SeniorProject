using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public virtual int customerId { get; set; }
        public virtual string firstName { get; set; }
        public virtual string  middleName { get; set; }
        public virtual string lastName { get; set; }
        public virtual double total { get; set; }
        public virtual string phoneNumber { get; set; }
               
        public virtual Discount discount { get; set; }

        public virtual IList<Account> account { get; set; }
        public virtual IList<Transactions> transactions { get; set; }
        public virtual IList<SaleItem> saleItems { get; set; }

        public Customer()
        {
            transactions = new List<Transactions>();
            saleItems = new List<SaleItem>();
            account = new List<Account>();
        }

        //copy constructor
        public Customer(Customer customer)
        {
            this.customerId = customer.customerId;
            this.firstName = customer.firstName;
            this.middleName = customer.middleName;
            this.lastName = customer.lastName;
            this.total = customer.total;
            this.phoneNumber = customer.phoneNumber;
            this.discount = customer.discount;
            this.account = customer.account;
            this.transactions = customer.transactions;
            this.saleItems = customer.saleItems;
        }
    }         
}
