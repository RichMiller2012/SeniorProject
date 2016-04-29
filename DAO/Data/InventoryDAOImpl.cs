using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NHibernate;
using NHibernate.Linq;
using Domain.NHConfiguration; 

namespace DAO.Data
{
    public class InventoryDAOImpl : AbstractBaseDAO, InventoryDAO
    {
        public List<Inventory> getAllInventories()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var inventory = session.CreateCriteria<Inventory>().List<Inventory>();
                    return (List<Inventory>)inventory;
                }
            }
        }

        public Inventory getInventoryById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var inventory = session.QueryOver<Inventory>()
                        .Where(inv => inv.inventoryId == id)
                        .Fetch(i => i.items).Eager
                        .SingleOrDefault();
                    return (Inventory)inventory;            
                }
            }
        }

        public List<Inventory> getStoreInventories(int storeId, bool withItems)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var invs = session.QueryOver<Inventory>()
                        .Where(inv => inv.store.storeId == storeId)
                        .List<Inventory>();

                    if (withItems) return mapInventoryListWthItems(invs);
                    else return mapInventoryWithoutItems(invs);              
                }
            }
        }


        private List<Inventory> mapInventoryListWthItems(ICollection<Inventory> inventories)
        {
            List<Inventory> storeInventories = new List<Inventory>();

            foreach (Inventory inv in inventories)
            {
                storeInventories.Add(new Inventory(inv));
            }

            return storeInventories;
        }

        private List<Inventory> mapInventoryWithoutItems(ICollection<Inventory> inventories)
        {
            List<Inventory> storeInventories = new List<Inventory>();

            foreach (Inventory inv in inventories)
            {
                Inventory newInventory = new Inventory();

                newInventory.inventoryId = inv.inventoryId;
                newInventory.name = inv.name;

                storeInventories.Add(newInventory);
            }

            return storeInventories;
        }

        public void updateInventory(Inventory inventory)
        {
            this.save(inventory);
        }

        public void updateItem(Item item)
        {
            this.save(item);
        }
    }
}
