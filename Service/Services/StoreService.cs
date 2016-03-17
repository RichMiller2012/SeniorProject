using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Services
{
    public interface StoreService
    {
        //Allow the user to view available inventory sets
        Inventory getInventoryById(int inventoryId);

        //Allow the user to see the wholesale value of the inventory
        Double getWholesaleValueOfInventory(int inventoryId);

        //Allow the user to view current customers
        List<Customer> viewStoreCustomers(int storeId);

        //Allow the user to view transaction history
        List<Transactions> viewStoreTransactions(int storeId);

        //Allow the user to view data on the current discounts
        List<Discount> viewStoreDiscounts(int storeId);

        //Allow the user to view all items sold
        List<SaleItem> viewAllSaleItems(int storeId);

    }
}
