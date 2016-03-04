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
    }
}
