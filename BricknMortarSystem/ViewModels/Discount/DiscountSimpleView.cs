using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModels.Discount
{
    public class DiscountSimpleView
    {
        public int discountId { get; set; }
        public double percentRate { get; set; }
        public double amount { get; set; }
    }
}