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
    public class ItemDAOImpl : ItemDAO
    {
        public List<Item> getAllItems()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var items = session.CreateCriteria<Item>().List<Item>();
                    return (List<Item>)items;
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

                    return (List<Item>)((Inventory)inventory).items;
                }
            }
        }

        public List<Item> getItemsByStore(int storeId)
        {
            //TO-DO
            return null;
        }

        public Item getItemByBarcode(string barcode)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var item = session.QueryOver<Item>()
                        .JoinAlias(x => x.barcodes, () => barcode)
                        .SingleOrDefault();

                    return (Item)item;
                }
            }
        }
        public Item getITemByPartNo(string partNo)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var item = session.QueryOver<Item>()
                        .JoinAlias(x => x.partNos, () => partNo)
                        .SingleOrDefault();

                    return (Item)item;
                }
            }
        }
    }
}
