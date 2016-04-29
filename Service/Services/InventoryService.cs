/**
 * Service Class to handle all aspects of inventory mangement. 
 * --Handles the creation of new items
 * --Updates item quantities
 * --Updates item data
 * --Asigns an inventory to a store
 * --
 **/

using System;
using System.Collections.Generic;
using DAO.Data;
using Domain.Entities;

namespace Service.Services
{
    public class InventoryService
    {

        InventoryDAO inventoryDAO;

        ItemDAO itemDAO;

        StoreDAO storeDAO;

        public InventoryService()
        {
            inventoryDAO = new InventoryDAOImpl();
            itemDAO = new ItemDAOImpl();
            storeDAO = new StoreDAOImpl();
        }


/********************************************
         * GET methods
         * 
********************************************/

        //get store inventories
        public List<Inventory> getStoreInventories(int storeId)
        {
            return inventoryDAO.getStoreInventories(storeId, false);
        }

        //get a specific inventory
        public Inventory getInventory(int inventoryId)
        {
            return inventoryDAO.getInventoryById(inventoryId);
        }

        //get all the items company wide
        public List<Item> getAllCompanyItems()
        {
            List<Item> accumulatedItems = itemDAO.getAllItems();

            //group items by their barcode
            Dictionary<string, Item> groupedItems = new Dictionary<string, Item>();

            foreach(Item item in accumulatedItems)
            {
                string key = "";
                try
                {
                    key = item.barcodes[0].number;
                }
                catch (Exception e)
                {
                    continue;
                }
                //get the first code, should not be null
                if (!groupedItems.ContainsKey(key))
                {
                    //add the item if it does not exists
                    groupedItems[key] = item;
                }
                else
                {
                    //if it exists then add the quantity
                    groupedItems[key].quantity += item.quantity;
                } 
            }

            accumulatedItems = new List<Item>();

            foreach (KeyValuePair<string, Item> entry in groupedItems)
            {
                accumulatedItems.Add(entry.Value);
            }

            return accumulatedItems;
        }

        //get all the items store wide
        public List<Item> getAllStoreItems(int storeId)
        {
            List<Inventory> inventories = inventoryDAO.getStoreInventories(storeId, true);
            List<Item> items = new List<Item>();

            foreach (Inventory inv in inventories)
            {
                items.AddRange(inv.items);
            }

            return items;

        }

        //get all the items specific to a inventory
        public List<Item> getInventoryItems(int inventoryId)
        {
            return (List<Item>)inventoryDAO.getInventoryById(inventoryId).items;
        }

        //get a specific item in a specific inventory by barcode
        public Item getInventoryItemByBarcode(string barcode, int inventoryId)
        {
            return itemDAO.getItemByBarcode(barcode, inventoryId);
        }

        //get a specific item in a specific inventory by part no
        public Item getInventoryItemByPartNo(string partNo, int inventoryId)
        {
            return itemDAO.getItemByPartNo(partNo, inventoryId);
        }

        //add a quantity to an item, then return that item
        public Item addInventoryItemQuantity(int itemId, int quantity)
        {
            if (itemId == 0) 
            {
                return null;
            }

            Item item = itemDAO.getItemById(itemId);

            if (item.itemId != 0)
            {
                item.quantity += quantity;
                itemDAO.save(item);

                return item;
            }
            else
            {
                return null;
            }
        }

        //remove the quantity from an item and return that item
        public Item removeInventoryItemQuantity(int itemId, int quantity)
        {
            Item item = itemDAO.getItemById(itemId);

            if (item != null)
            {
                if (item.quantity <= quantity)
                {
                    item.quantity = 0;
                }
                else
                {
                    item.quantity -= quantity;
                }
            }

            itemDAO.save(item);

            return item;
        }

/********************************************
         * Post methods
         * 
********************************************/

        //add a new item to the inventory, return items Id
        public int addInventoryItem(Item item, int inventoryId)
        {
            string barcode = item.barcodes[0].number;

            if (barcode == null)
            {
                //Log an error
                return 0;
            }

            Inventory inventory = inventoryDAO.getInventoryById(inventoryId);

            inventory.items.Add(item);

            //get the item just added
            Item addedItem = itemDAO.getItemByBarcode(barcode, inventoryId);

            return addedItem.itemId;
        }

        //add a new inventory to a store
        public int addNewInventory(Inventory inventory, int storeId)
        {
            Store store = storeDAO.getStoreByID(storeId);
            store.inventories.Add(inventory);

            return inventoryDAO.save(inventory);
        }

/********************************************
         * Business logic methods
         * 
********************************************/

        //return if an inventory item already exists by barcode
        public bool inventoryContainsBarcode(int inventoryId, string barcode)
        {
            Item hasItem = itemDAO.getItemByBarcode(barcode, inventoryId);

            if (hasItem == null) return false;
            else return true;
        }

        //rturn if an inventory item already exists by part number
        public bool inventoryContainsPartNo(int inventoryId, string partNo)
        {
            Item hasItem = itemDAO.getItemByPartNo(partNo, inventoryId);

            if (hasItem == null) return false;
            else return true;
        }
    }
}
