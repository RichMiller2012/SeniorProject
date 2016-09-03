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
        public virtual IList<Store> stores { get; set; }

        public Customer()
        {
            transactions = new List<Transactions>();
            saleItems = new List<SaleItem>();
            account = new List<Account>();
            stores = new List<Store>();
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Customer c = (Customer)obj;

            return customerId == c.customerId &&
                firstName == c.firstName &&
                middleName == c.middleName &&
                lastName == c.lastName &&
                phoneNumber == c.phoneNumber &&
                total == c.total;
        }
    }         
}
