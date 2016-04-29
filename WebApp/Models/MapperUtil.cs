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

        public static TransactionViewModelSimple mapTransactionSimple(Transactions trans)
        {
            Mapper.CreateMap<Transactions, TransactionViewModelSimple>();

            TransactionViewModelSimple tvs = Mapper.Map<Transactions, TransactionViewModelSimple>(trans);

            return tvs;
        }

       public static TransactionViewModelDetailed mapTransaction(Transactions trans)
       {
           Mapper.CreateMap<Transactions, TransactionViewModelDetailed>();

           TransactionViewModelDetailed tvm = Mapper.Map<Transactions, TransactionViewModelDetailed>(trans);

           foreach (SaleItem si in trans.saleItems)
           {
               tvm.customerViewModel = mapCustomerSimple(trans.customer);
               tvm.storeId = trans.store.storeId;
               tvm.saleItemViewModels.Add(mapSaleItem(si));
           }

           return tvm;
       }

       public static Transactions mapTransactionViewModel(TransactionViewModelDetailed trans)
       {
           Mapper.CreateMap<TransactionViewModelDetailed, Transactions>();

           Transactions t = Mapper.Map<TransactionViewModelDetailed, Transactions>(trans);

           foreach (SaleItemViewModel sivm in trans.saleItemViewModels)
           {
               t.saleItems.Add(mapSaleItemViewModel(sivm));
           }

           return t;
       }

        public static SaleItemViewModel mapSaleItem(SaleItem saleItem)
        {
            Mapper.CreateMap<SaleItem, SaleItemViewModel>();

            SaleItemViewModel sivm = Mapper.Map<SaleItem, SaleItemViewModel>(saleItem);

            return sivm;
        }

        public static SaleItem mapSaleItemViewModel(SaleItemViewModel saleItemViewModel)
        {
            Mapper.CreateMap<SaleItemViewModel, SaleItem>();

            SaleItem si = Mapper.Map<SaleItemViewModel, SaleItem>(saleItemViewModel);

            return si;

        }

        public static CustomerViewModelSimple mapCustomerSimple(Customer customer)
        {
            Mapper.CreateMap<Customer, CustomerViewModelSimple>();

            CustomerViewModelSimple cvms = Mapper.Map<Customer, CustomerViewModelSimple>(customer);

            return cvms;
        }

        public static CustomerViewModelDetailed mapCustomerDetailed(Customer customer)
        {
            Mapper.CreateMap<Customer, CustomerViewModelDetailed>();

            CustomerViewModelDetailed cvmd = Mapper.Map<Customer, CustomerViewModelDetailed>(customer);

            List<TransactionViewModelSimple> transactionViews = new List<TransactionViewModelSimple>();
            List<SaleItemViewModel> saleItemViews = new List<SaleItemViewModel>();

            foreach(Transactions t in customer.transactions)
            {
                transactionViews.Add(MapperUtil.mapTransactionSimple(t));
            }

            foreach(SaleItem si in customer.saleItems)
            {
                saleItemViews.Add(MapperUtil.mapSaleItem(si));
            }

            cvmd.saleItemViews = saleItemViews;
            cvmd.transactionViews = transactionViews;

            return cvmd;

            

                
        }

        public static InventoryViewModelSimple mapInventorySimple(Inventory inventory)
        {
            Mapper.CreateMap<Inventory, InventoryViewModelSimple>();

            InventoryViewModelSimple ivms = Mapper.Map<Inventory, InventoryViewModelSimple>(inventory);

            return ivms;
        }


    
    }
}
