﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using NHibernate;
using NHibernate.Linq;
using Domain.NHConfiguration;


namespace DAO.Data
{
    public class TransactionsDAOImpl : AbstractBaseDAO, TransactionsDAO
    {
        public List<Transactions> viewAllStoreTransactions(int storeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                //Store storeAlias = null;

                using (ITransaction transaction = session.BeginTransaction())
                {
                    var transactions = session.QueryOver<Transactions>()
                        .Where(s => s.store.storeId == storeId)
                        .List<Transactions>();

                    return mapToList(transactions);
                }
            }
        }

        public List<Transactions> getAllTransactions()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var Transaction = session.CreateCriteria<Transactions>().List<Transactions>();
                    return (List<Transactions>)Transaction;
                }
            }
        }

        public string getLastTransactionNumber()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    var query = session.CreateSQLQuery(
                        
                        "SELECT * FROM Transactions t WHERE t.transactionId = (SELECT MAX(transactionId) FROM Transactions)"
                        ).AddEntity("transaction", typeof(Transactions)).UniqueResult();

                    return ((Transactions)query).transactionNumber;
                }
            }
        }

        public List<Transactions> getTransactionByCustomer(int customerId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var cust = session.QueryOver<Customer>()
                        .Where(c => c.customerId == customerId)
                        .Fetch(t => t.transactions).Eager
                        .SingleOrDefault();

                    Customer customer = (Customer)cust;

                    return mapToList(customer.transactions);
                }
            }
        }
        public Transactions getTransactionByNumber(string transactionNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Transactions trans = session.QueryOver<Transactions>()
                        .Where(t => t.transactionNumber == transactionNumber)
                        .SingleOrDefault();

                    return (Transactions)trans;
                }
            }
        }

        private List<Transactions> mapToList(ICollection<Transactions> transactions)
        {
            List<Transactions> trans = new List<Transactions>();
            foreach (Transactions t in transactions)
            {
                t.customer = new Customer(t.customer);
                t.saleItems = mapSaleItemsToTransaction(t.saleItems);
                trans.Add(t);        
            }

            return trans;
        }

        private List<SaleItem> mapSaleItemsToTransaction(ICollection<SaleItem> saleItems)
        {
            List<SaleItem> ListSaleItems = new List<SaleItem>();
            foreach (SaleItem si in saleItems)
            {
                ListSaleItems.Add(si);
            }

            return ListSaleItems;
        }
    }
}
