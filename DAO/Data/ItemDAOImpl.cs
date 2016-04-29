/**
 * Implementation class for retrieval of Items.
 * Add additional methods as needed. All methods have
 * been functionally tested. Tests are associated with Seed.cs
 * 
 **/ 
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
    public class ItemDAOImpl : AbstractBaseDAO, ItemDAO
    {
        public List<Item> getAllItems()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var items = session.QueryOver<Item>()
                        .Fetch(b => b.barcodes).Lazy
                        .Fetch(p => p.partNos).Lazy
                        .List<Item>();

                    return mapToList(items);
                }
            }
        }

        public List<Item> getItemsByInventory(int inventoryId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var inventory = session.QueryOver<Inventory>()
                        .Where(i => i.inventoryId == inventoryId)
                        .Fetch(i => i.items).Eager
                        .SingleOrDefault();

                    Inventory inv = (Inventory)inventory;

                    return mapToList(inv.items);
                }
            }
        }

        public Item getItemById(int itemId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var item = session.QueryOver<Item>()
                        .Where(id => id.itemId == itemId)
                        .SingleOrDefault();

                    return new Item((Item)item);
                }
            }
        }

        public Item getItemByBarcode(string barcode, int inventoryId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Barcode barcodeAlias = null;

                    
                    var item = session.QueryOver<Item>()
                        .Where(i => i.inventory.inventoryId == inventoryId)
                        .JoinAlias(x => x.barcodes, () => barcodeAlias)
                        .Where(() => barcodeAlias.number == barcode)
                        .List<Item>();

                    try
                    {
                        return (Item)(mapToList(item)[0]);
                    }
                    catch (Exception e)
                    {
                        //log
                        return new Item();
                    }
                }
            }
        }
        public Item getItemByPartNo(string partNo, int inventoryId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    PartNo partNoAlias = null;

                    var item = session.QueryOver<Item>()
                        .Where(i => i.inventory.inventoryId == inventoryId)
                        .JoinAlias(x => x.partNos, () => partNoAlias)
                        .Where(() => partNoAlias.number == partNo)
                        .List<Item>();

                    try
                    {
                        return (Item)(mapToList(item)[0]);
                    }
                    catch (Exception e)
                    {
                        //log
                        return new Item();
                    }
                }
            }
        }

        public void updateItem(Item item)
        {
            this.save(item);
        }

        private List<Item> mapToList(ICollection<Item> items)
        {
            List<Item> listItems = new List<Item>();
            foreach (Item item in items)
            {
                listItems.Add(new Item(item));
            }

            return listItems;
        }
    }
}
