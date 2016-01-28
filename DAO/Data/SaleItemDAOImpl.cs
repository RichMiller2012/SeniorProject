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
    public class SaleItemDAOImpl
    {
        List<SaleItem> getAllSaleItems()
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
        List<SaleItem> getSaleItemsByTransactionNumber(string transactionNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var trans = session.QueryOver<Transactions>()
                        .Where(t => t.transactionNumber == transactionNumber)
                        .Fetch(si => si.saleItems).Eager
                        .List<SaleItem>();

                   return (List<SaleItem>)((Transactions)trans).saleItems;
                }
            }
        }
        List<SaleItem> getSaleItemsByCustomer(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var cust = session.QueryOver<Customer>()
                        .Where(c => c == customer)
                        .Fetch(si => si.saleItems).Eager
                        .List<SaleItem>();

                    return (List<SaleItem>)((Customer)cust).saleItems;
                }
            }
        }
        SaleItem getSaleItemByBarcode(string barcode)
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
        SaleItem getSaleItemByPartNo(string partNo)
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
    }
}
