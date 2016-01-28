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
    public class TransactionsDAOImpl
    {
        List<Transactions> getAllTransactions()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var Transaction = session.CreateCriteria<Transactions>().List<SaleItem>();
                    return (List<Transactions>)Transaction;
                }
            }
        }
        List<Transactions> getTransactionByCustomer(Customer customer)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var cust = session.QueryOver<Customer>()
                        .Where(c => c == customer)
                        .Fetch(t => t.transactions).Eager
                        .List<Transactions>();

                    return (List<Transactions>)((Customer)cust).transactions;
                }
            }
        }
        Transactions getTransactionByNumber(string transactionNumber)
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
    }
}
