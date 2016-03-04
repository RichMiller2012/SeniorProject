using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using DAO.Data;

namespace Service.Services
{
    
    public class ItemServiceImpl : ItemService
    {
        private ItemDAO dao;

        public ItemServiceImpl(ItemDAO dao)
        {
            this.dao = dao;
        }

        public Item getItemByBarcode(string barcode)
        {
            return dao.getItemByBarcode(barcode);
        }

        public Item getItemByPartNumber(string partNo)
        {
            return dao.getItemByPartNo(partNo);
        }

        public void addNewItem(Item item)
        {
            dao.save(item);
        }

        public ICollection<Item> viewAllnventoryItems(int inventoryId)
        {
            return dao.getItemsByInventory(inventoryId);
        }

        public int lowInventoryLevel(Item item)
        {
            throw new NotImplementedException();
        }

        public void sellItem(Item item, int quantity = 1)
        {
            if (item.quantity <= quantity)
            {
                item.quantity = 0;
            }
            else
            {
                item.quantity -= quantity;
            }

            //log message indicating more items were sold then in inventory

            dao.save(item);  
        }

        public void receiveItem(Item item, int quantity = 1)
        {
            item.quantity += quantity;
            dao.save(item);
        }

        public double calculateTax(Item item, int quantity = 1, double taxRate)
        {
            return item.retailPrice * quantity * taxRate;
        }
    }
}
