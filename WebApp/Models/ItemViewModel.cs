using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using AutoMapper;

namespace WebApp.Models
{
    public class ItemViewModel
    {
        public int itemId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double retailPrice { get; set; }
        public double wholesalePrice { get; set; }
        public int quantity { get; set; }


        public IList<string> barcodes { get; set; }
        public  IList<string> partNos { get; set; }
        public  IList<Dates> inDate { get; set; }
    }
}