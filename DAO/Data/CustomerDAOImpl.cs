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
    public class CustomerDAOImpl : AbstractBaseDAO, CustomerDAO
    {
        public List<Customer> getAllCustomers()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var customers = session.CreateCriteria<Customer>().List<Customer>();
                    return (List<Customer>)customers;
                }
            }
        }

        public List<Customer> getCustomersByFirstName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Customer> customers = session.QueryOver<Customer>()
                        .Where(c => c.firstName == name)
                        .List<Customer>();
                    return (List<Customer>)customers;
                }
            }
        }

        public List<Customer> getCustomersByLastName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Customer> customers = session.QueryOver<Customer>()
                        .Where(c => c.lastName == name)
                        .List<Customer>();
                    return (List<Customer>)customers;
                }
            }
        }

        public List<Customer> getCustomersByMiddleName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Customer> customers = session.QueryOver<Customer>()
                        .Where(c => c.middleName == name)
                        .List<Customer>();
                    return (List<Customer>)customers;
                }
            }
        }

        public List<Customer> getCustomersByStore(int storeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var queryStore = session.QueryOver<Store>()
                        .Where(s => s.storeId == storeId)
                        .Fetch(c => c.customers).Eager
                        .SingleOrDefault();

                    Store store = (Store)queryStore;

                    return mapToList(store.customers);
                }
            }
        }

        public Customer getCustomerByPhoneNumber(string number)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Customer customers = session.QueryOver<Customer>()
                        .Where(c => c.phoneNumber == number)
                        .SingleOrDefault();
                    return (Customer)customers;
                }
            }
        }

        public Customer getCustomerByTransactionNumber(string number)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {                 
                    var trans = session.QueryOver<Transactions>()
                        .Where(t => t.transactionNumber == number)
                        .Fetch(e => e.customer).Eager
                        .SingleOrDefault();

                    Transactions tr = (Transactions)trans;

                    return tr.customer;
                    
                }
            }
        }

        public Customer getCustomerByAccountNumber(string number)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {                 
                    var account = session.QueryOver<Account>()
                        .Where(a => a.number == number)
                        .Fetch(c => c.customer).Eager
                        .SingleOrDefault();
                    return ((Account)account).customer;
                        
                }
            }
        }

        public Customer getCustomerByID(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Customer customer = session.QueryOver<Customer>()
                        .Where(c => c.customerId == id)
                        .SingleOrDefault();
                    return (Customer)customer;
                }
            }
        }

        private List<Customer> mapToList(ICollection<Customer> customers)
        {
            List<Customer> listCustomers = new List<Customer>();
            foreach (Customer c in customers)
            {
                listCustomers.Add(c);
            }

            return listCustomers;
        }
    }
}
