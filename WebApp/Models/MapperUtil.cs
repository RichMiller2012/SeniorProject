using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using AutoMapper;

namespace WebApp.Models
{
    public static class MapperUtil
    {
       public static ItemViewModel mapItem(Item item)
       {
           Mapper.CreateMap<Item, ItemViewModel>();
           ItemViewModel vm = Mapper.Map<Item, ItemViewModel>(item);

           vm.barcodes = new List<string>();
           vm.partNos = new List<string>();

           foreach (Barcode b in item.barcodes)
           {
               vm.barcodes.Add(b.number);
           }

           foreach(PartNo pn in item.partNos)
           {
               vm.partNos.Add(pn.number);
           }

           return vm;
       }
    
    }
}
