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
    public class DiscountDAOImpl : AbstractBaseDAO
    {
        public List<Discount> getAllDiscounts()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var discount = session.CreateCriteria<Discount>().List<Discount>();
                    return (List<Discount>)discount;
                }
            }
        }

        public List<Discount> getDiscountByStore(Store store)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var queryStore = session.QueryOver<Store>()
                        .Where(s => s == store)
                        .Fetch(d => d.discounts).Eager
                        .SingleOrDefault();

                    return (List<Discount>)((Store)queryStore).discounts;
                }
            }
        }

        public Discount getDiscountById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Discount discount = session.QueryOver<Discount>()
                       .Where(c => c.discountId == id)
                       .SingleOrDefault();

                    return discount;
                }
            }            
        }
    }
}
