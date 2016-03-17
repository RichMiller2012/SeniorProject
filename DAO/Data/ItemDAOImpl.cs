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
        public List<Item> getItemsByInDateRange(DateTime inDay, DateTime outDay)
        {
            //TO-DO
            return null;
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

        public List<Item> getItemsByStore(int storeId)
        {
            //TO-DO
            return null;
        }

        public Item getItemById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Item item = session.QueryOver<Item>()
                        .Where(i => i.itemId == id)
                        .SingleOrDefault();
                    return (Item)item;
                }
            }
        }

        public Item getItemByBarcode(string barcode)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Barcode barcodeAlias = null;

                    var item = session.QueryOver<Item>()
                        .JoinAlias(x => x.barcodes, () => barcodeAlias)
                        .Where(() => barcodeAlias.number == barcode)
                        .List<Item>();

                    return (Item)(mapToList(item)[0]);
                }
            }
        }
        public Item getItemByPartNo(string partNo)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    PartNo partNoAlias = null;

                    var item = session.QueryOver<Item>()
                        .JoinAlias(x => x.partNos, () => partNoAlias)
                        .Where(() => partNoAlias.number == partNo)
                        .List<Item>();

                    return (Item)(mapToList(item)[0]);
                }
            }
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
