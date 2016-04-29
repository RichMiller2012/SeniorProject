using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAO.Data
{
    public interface InventoryDAO
    {
        //**********GET methods*************

        //get all the inentories
        List<Inventory> getAllInventories();

        //get an inventory by its id
        Inventory getInventoryById(int id);

        //get all the store's inventories
        List<Inventory> getStoreInventories(int storeId, bool withItems);

        //**********POST methods************

        //update inventory with a new item
        void updateInventory(Inventory invetory);

        int save(object inventory);
    }
}
