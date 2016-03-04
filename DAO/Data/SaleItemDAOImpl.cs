/**
 * Implementation class for retrieval of SaleItems.
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
    public class SaleItemDAOImpl : AbstractBaseDAO, SaleItemDAO
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
        //
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

        //
        public List<SaleItem> getSaleItemsByStore(Store store)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    List<SaleItem> saleItems = new List<SaleItem>();

                    var  trans = session.QueryOver<Transactions>()
                        .JoinAlias(x => x.saleItems, () => saleItems)
                        .Where(s => s.store.storeId == store.storeId)
                        .List<Transactions>();

                    foreach(Transactions t in ((List<Transactions>)trans))
                    {
                        saleItems.AddRange(mapToList(t.saleItems));
                    }

                    return saleItems;
                }
            }
        }

        //
        public SaleItem getSaleItemByBarcode(string barcode)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    //only getting one result. Need to make sure each barcode
                    //is associated with one item
                    Barcode barcodeAlias = null;

                    var item = session.QueryOver<SaleItem>()
                        .JoinAlias(x => x.barcodes, () => barcodeAlias)
                        .Where(() => barcodeAlias.number == barcode)
                        .List<SaleItem>();
                        
                                             
                    return (SaleItem)(mapToList(item)[0]);
                }
            }
        }
        //
        public SaleItem getSaleItemByPartNo(string partNo)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    PartNo partNoAlias = null;
                    //only getting one result. Need to make sure each partNo
                    //is associated with one item
                    var item = session.QueryOver<SaleItem>()
                        .JoinAlias(x => x.partNos, () => partNoAlias)
                        .Where(() => partNoAlias.number == partNo)
                        .List<SaleItem>();

                    return (SaleItem)(mapToList(item)[0]);
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
