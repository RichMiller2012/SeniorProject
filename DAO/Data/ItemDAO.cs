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

        List<Item> getItemsByInventory(int inventroyId);

        Item getItemById(int id);

        Item getItemByBarcode(string barcode, int inventoryId);

        Item getItemByPartNo(string partNo, int inventoryId);

        int save(object obj);
    }
}
