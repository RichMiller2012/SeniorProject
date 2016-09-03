using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
 *  Simple view model to display all the basic data to produce a list of customers
 */

namespace ViewModels.Customer
{
    public class CustomerViewAll
    {
        public virtual int customerId { get; set; }
        public virtual string firstName { get; set; }
        public virtual string middleName { get; set; }
        public virtual string lastName { get; set; }
        public virtual double total { get; set; }
        public virtual string phoneNumber { get; set; }
    }
}