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
    public class StoreDAOImpl : AbstractBaseDAO, StoreDAO
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
    }
}
