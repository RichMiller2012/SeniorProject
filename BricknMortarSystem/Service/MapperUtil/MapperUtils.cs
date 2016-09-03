using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using AutoMapper;
using ViewModels.Customer;
using ViewModels.Transaction;
using ViewModels.SaleItem;
using ViewModels.Discount;
using ViewModels.Item;
using ViewModels.Inventory;
using ViewModels.Identifiers;

namespace Service.MapperUtil
{
    public static class MapperUtil
    {
        /**
         *  Detailed Model mappers. Involve the use of one or more basic mappers
         */
        public static ItemDetailView mapItemDetailView(Item item)
        {
            Mapper.CreateMap<Item, ItemDetailView>();
            ItemDetailView idv = Mapper.Map<Item, ItemDetailView>(item);

            foreach (Barcode barcode in item.barcodes)
            {
                idv.barcodeViews.Add(mapBarcodeView(barcode));
            }

            foreach (PartNo partNo in item.partNos)
            {
                idv.partNoViews.Add(mapPartNoView(partNo));
            }

            return idv;
        }
        public static InventoryDetailView mapInventoryDetailView(Inventory inventory)
        {
            Mapper.CreateMap<Inventory, InventoryDetailView>();
            InventoryDetailView idv = Mapper.Map<Inventory, InventoryDetailView>(inventory);

            foreach (Item item in inventory.items)
            {
                idv.itemViewAlls.Add(mapItemViewAll(item));
            }

            return idv;
        }
        
        public static DiscountSimpleView mapDiscountSimpleView(Discount discout)
        {
            Mapper.CreateMap<Discount, DiscountSimpleView>();
            DiscountSimpleView dsv = Mapper.Map<Discount, DiscountSimpleView>(discout);
            return dsv;
        }

        public static DiscountDetailView mapDiscountDetailView(Discount discount)
        {
            Mapper.CreateMap<Discount, DiscountDetailView>();
            DiscountDetailView ddv = Mapper.Map<Discount, DiscountDetailView>(discount);

            foreach (Customer c in discount.customers)
            {
                ddv.customerViewAlls.Add(mapCustomerViewAll(c));
            }

            return ddv;
        }
        public static CustomerViewSaleItem mapCustomerViewSaleItem(Customer customer)
        {
            Mapper.CreateMap<Customer, CustomerViewSaleItem>();
            CustomerViewSaleItem cvsi = Mapper.Map<Customer, CustomerViewSaleItem>(customer);

            foreach (SaleItem saleItem in customer.saleItems)
            {
                cvsi.saleItemViewAlls.Add(mapSaleItemViewAll(saleItem));
            }

            return cvsi;
        }

        public static CustomerDetailView mapCustomerDetailView(Customer customer)
        {
            Mapper.CreateMap<Customer, CustomerDetailView>();
            CustomerDetailView cdv = Mapper.Map<Customer, CustomerDetailView>(customer);

            foreach (Transactions trans in customer.transactions)
            {
                cdv.transactionsViewAlls.Add(mapTransactionViewAll(trans));
            }

            cdv.discountSimpleView = mapDiscountSimpleView(customer.discount);

            return cdv;
        }
    
        /**
         *  Basic model mappers
         */
        //maps a customer model to all the basic data needed for a large list of customers
        public static BarcodeView mapBarcodeView(Barcode barcode)
        {
            Mapper.CreateMap<Barcode, BarcodeView>();
            return Mapper.Map<Barcode, BarcodeView>(barcode);

        }
        public static PartNoView mapPartNoView(PartNo partNo)
        {
            Mapper.CreateMap<PartNo, PartNoView>();
            return Mapper.Map<PartNo, PartNoView>(partNo);
        }
        public static InventoryViewAll mapInventoryViewAll(Inventory inventory)
        {
            Mapper.CreateMap<Inventory, InventoryViewAll>();
            InventoryViewAll iva = Mapper.Map<Inventory, InventoryViewAll>(inventory);
            return iva;
        }
        public static ItemViewAll mapItemViewAll(Item item)
        {
            Mapper.CreateMap<Item, ItemViewAll>();
            ItemViewAll iva = Mapper.Map<Item, ItemViewAll>(item);
            return iva;
        }

        public static  CustomerViewAll mapCustomerViewAll(Customer customer)
        {
            Mapper.CreateMap<Customer, CustomerViewAll>();
            CustomerViewAll cva = Mapper.Map<Customer, CustomerViewAll>(customer);
            return cva;
        }

        //maps a transaction to all the basic data needed for a large list of transactions
        public static TransactionViewAll mapTransactionViewAll(Transactions trans)
        {
            Mapper.CreateMap<Transactions, TransactionViewAll>();
            TransactionViewAll tva = Mapper.Map<Transactions, TransactionViewAll>(trans);
            return tva;
        }

        public static SaleItemViewAll mapSaleItemViewAll(SaleItem saleItem)
        {
            Mapper.CreateMap<SaleItem, SaleItemViewAll>();
            SaleItemViewAll sva = Mapper.Map<SaleItem, SaleItemViewAll>(saleItem);

            foreach (Barcode barcode in saleItem.barcodes)
            {
                sva.barcodeViews.Add(barcode.number);
            }

            foreach (PartNo partNo in saleItem.partNos)
            {
                sva.partNoViews.Add(partNo.number);
            }

            return sva;
        }

    }
}