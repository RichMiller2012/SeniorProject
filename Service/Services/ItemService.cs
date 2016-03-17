using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Services
{
    public interface ItemService
    {
        List<Item> getAllItems();

        //lookup item by barcode
        Item getItemByBarcode(string barcode);
        //lookup item by part number
        Item getItemByPartNumber(string partNo);
        //add a new item
        void addNewItem(Item item);
        //view all items
        ICollection<Item> viewAllnventoryItems(int inventoryId);




        /*
         * Based off desired business logic, calculate what the 
         * desired low invenory level will be for a specific item
         */
        int lowInventoryLevel(Item item);

        /*
         * retrieve an item from the database and sell
         * at least one of them
         */
        void sellItem(Item item, int quantity = 1);

        /*
         * receive an item, track wholesale price and 
         * add at least o to inventory
         */
        void receiveItem(Item item, int quantity = 1);

        /*
         * calculate the tax based off the rate of an item when it is sold
         */
        double calculateTax(Item item, double taxRate, int quantity = 1);
    }
}
