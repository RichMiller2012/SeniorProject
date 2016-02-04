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
    public class SaleItemDAOImpl : SaleItemDAO
    {
        //
        public List<SaleItem> getAllSaleItems()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var saleItem = session.CreateCriteria<SaleItem>().List<SaleItem>();
                    return (List<SaleItem>)saleItem;
                }
            }
        }
        //
        public List<SaleItem> getSaleItemsByTransactionNumber(string transactionNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var trans = session.QueryOver<Transactions>()
                        .Where(t => t.transactionNumber == transactionNumber)
                        .Fetch(si => si.saleItems).Eager
                        .SingleOrDefault();

                    Transactions solidTrans = (Transactions)trans;
                    return mapToList(solidTrans.saleItems);
                }
            }
        }

        public List<SaleItem> getSaleItemsByCustomer(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var cust = session.QueryOver<Customer>()
                        .Where(c => c.customerId == customer.customerId)
                        .Fetch(si => si.saleItems).Eager
                        .SingleOrDefault();

                    Customer dbCust = (Customer)cust;
                    return mapToList(dbCust.saleItems);
                }
            }
        }
        public List<SaleItem> getSaleItemsByStore(Store store)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    List<SaleItem> saleItems = null;

                    var  items = session.QueryOver<Transactions>()
                        .JoinAlias(x => x.saleItems, () => saleItems)
                        .Where(s => s.store == store)
                        .List<SaleItem>();

                    return saleItems;
                }
            }
        }
        public SaleItem getSaleItemByBarcode(string barcode)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var item = session.QueryOver<SaleItem>()
                        .JoinAlias(x => x.barcodes, () => barcode)
                        .SingleOrDefault();

                    return (SaleItem)item;
                }
            }
        }
        public SaleItem getSaleItemByPartNo(string partNo)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var item = session.QueryOver<SaleItem>()
                        .JoinAlias(x => x.partNos, () => partNo)
                        .SingleOrDefault();

                    return (SaleItem)item;
                }
            }
        }

        private List<SaleItem> mapToList(ICollection<SaleItem> saleItems)
        {
            List<SaleItem> listItems = new List<SaleItem>();
            foreach (SaleItem item in saleItems)
            {
                listItems.Add(item);
            }

            return listItems;
        }
    }
}
