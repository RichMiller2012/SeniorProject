/*
 * Data access methods for Item
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAO.Data
{
    public interface ItemDAO
    {
        List<Item> getAllItems();

        List<Item> getItemsByInDateRange(DateTime inDay, DateTime outDay);

        List<Item> getItemsByInventory(int inventroyId);

        List<Item> getItemsByStore(int storeId);

        Item getItemById(int id);

        Item getItemByBarcode(string barcode);

        Item getItemByPartNo(string partNo);

        void save(object obj);
    }
}
