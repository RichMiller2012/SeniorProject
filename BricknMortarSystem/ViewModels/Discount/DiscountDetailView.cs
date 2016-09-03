using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.Customer;

namespace ViewModels.Discount
{
    public class DiscountDetailView
    {
        public int discountId { get; set; }
        public double percentRate { get; set; }
        public double amount { get; set; }

        public IList<CustomerViewAll> customerViewAlls { get; set; }

        public DiscountDetailView()
        {
            customerViewAlls = new List<CustomerViewAll>();
        }

    }
}