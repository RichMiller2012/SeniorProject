using System;


namespace WebApp.Models
{
    public class UpdateQuantity
    {
        public string barcode { get; set; }
        public int inventoryId { get; set; }
        public int qantity { get; set; }
    }
}
