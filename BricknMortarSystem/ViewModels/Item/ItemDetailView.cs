using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ViewModels.Identifiers;

namespace ViewModels.Item
{
    public class ItemDetailView
    {
        public int itemId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double retailPrice { get; set; }
        public double wholesalePrice { get; set; }
        public int quantity { get; set; }

        public List<BarcodeView> barcodeViews { get; set; }
        public List<PartNoView> partNoViews { get; set; }

        public ItemDetailView()
        {
            barcodeViews = new List<BarcodeView>();
            partNoViews = new List<PartNoView>();
        }
    }
}