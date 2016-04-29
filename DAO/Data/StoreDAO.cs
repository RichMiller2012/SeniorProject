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
    public interface StoreDAO
    {
        List<Store> getAllStores();
        Store getStoreByID(int id);
        Store getStoreByName(string name);
        int saveCustomerToStore(Customer customer, int storeId);
        int saveStore(Store store);
    }
}
