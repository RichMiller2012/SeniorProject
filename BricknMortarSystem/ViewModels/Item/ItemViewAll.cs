using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModels.Item
{
    public class ItemViewAll
    {
        public int itemId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double retailPrice { get; set; }
        public double wholesalePrice { get; set; }
        public int quantity { get; set; }
    }
}