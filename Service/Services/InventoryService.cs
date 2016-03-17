using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Services
{
    public interface InventoryService
    {
        //Add new items to the inventory
        int addItemToInventory(int inventoryId);
        //Update the quantity of an existing item
        void upateItemQuantity(Item item, int quantity);
        //Edit a selected Item
        void editItem(Item item);
        //Allow the user to view all items within an inventory
        List<Item> viewAllItemsInInventory(Inventory inv);
        //Calculate low inventory levels based on user defined formula
        int calculateLowInventoryLevel(Item item);
        //Provide a means of exporting the items into excel format
        void exportInventoryToExcel(Inventory inventory);

    }
}
