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
    public class StoreDAOImpl : AbstractBaseDAO
    {
        public List<Store> getAllStores()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var store = session.CreateCriteria<Store>().List<Store>();
                    return (List<Store>)store;
                }
            }
        }
        public Store getStoreByID(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var store = session.QueryOver<Store>()
                        .Where(s => s.storeId == id)
                        .Fetch(i => i.inventories).Eager
                        .SingleOrDefault();

                    return (Store)store;
                }
            }
        }
        public Store getStoreByName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var store = session.QueryOver<Store>()
                        .Where(s => s.name == name)
                        .SingleOrDefault();

                    return (Store)store;
                }
            }
        }

        public int saveCustomerToStore(Customer customer, int storeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Store store = session.Get<Store>(storeId);
                    store.customers.Add(customer);
                    customer.stores.Add(store);
                    
                    transaction.Commit();

                    return 1;
                }
            }
        }

        public double getStoreTaxRate(int storeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Store store = session.Get<Store>(storeId);

                    double taxRate = store.taxRate;

                    return taxRate;
                }
            }
        }

        public int saveStore(Store store)
        {
            return save(store);
        }
    }
}
