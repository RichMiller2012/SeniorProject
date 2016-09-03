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
    public class CustomerDAOImpl : AbstractBaseDAO
    {
        public List<Customer> getAllCustomers()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var customers = session.CreateCriteria<Customer>().List<Customer>();
                    return mapToList(customers);
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
                    return mapToList(customers);
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
                    return mapToList(customers);
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
                    return mapToList(customers);
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
                        .SingleOrDefault();

                    Store store = (Store)queryStore;

                    return mapToList(store.customers);
                }
            }
        }

        public Customer getCustomerByPhoneNumber(string number, bool withDetail)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Customer customer = session.QueryOver<Customer>()
                        .Where(c => c.phoneNumber == number)
                        .SingleOrDefault();

                    return mapDetailedCustomerData((Customer)customer);
                    
                }
            }
        }

        public Customer getCustomerByTransactionNumber(string number, bool withDetail)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {                 
                    var trans = session.QueryOver<Transactions>()
                        .Where(t => t.transactionNumber == number)
                        .Fetch(e => e.customer).Eager
                        .SingleOrDefault();

                    Customer customer = trans.customer;

                    if (withDetail)
                    {
                        return mapDetailedCustomerData((Customer)customer);
                    }
                    else
                    {
                        return new Customer((Customer)customer);
                    }                   
                }
            }
        }

        public Customer getCustomerByAccountNumber(string number, bool withDetail)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {                 
                    var account = session.QueryOver<Account>()
                        .Where(a => a.number == number)
                        .Fetch(c => c.customer).Eager
                        .SingleOrDefault();

                    Customer customer = account.customer;

                    if (withDetail)
                    {
                        return mapDetailedCustomerData((Customer)customer);
                    }
                    else
                    {
                        return new Customer((Customer)customer);
                    }                       
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

                       return mapDetailedCustomerData((Customer)customer);
                }
            }
        }

        public int addSaleItemToCustomer(SaleItem saleItem, int custId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Customer cust = session.Get<Customer>(custId);
                    cust.saleItems.Add(saleItem);
                    saleItem.customers.Add(cust);

                    transaction.Commit();

                    return 1;
                }
            }
        }

        public int saveCustomer(Customer customer)
        {
            return save(customer);
        }


        //Mapper functions

        private List<Customer> mapToList(ICollection<Customer> customers)
        {
            List<Customer> listCustomers = new List<Customer>();
            foreach (Customer c in customers)
            {

                listCustomers.Add(new Customer(mapDetailedCustomerData(c)));
            }

            return listCustomers;
        }

        private Customer mapDetailedCustomerData(Customer customer)
        {
            Customer newCustomer = new Customer(customer);
            
            List<SaleItem> saleItems = new List<SaleItem>();
            List<Transactions> transactions = new List<Transactions>();


            foreach (SaleItem si in customer.saleItems)
            {
                saleItems.Add(new SaleItem(si));
            }

            foreach (Transactions t in customer.transactions)
            {
                transactions.Add(new Transactions(t));
            }

            if (customer.discount == null)
            {
                newCustomer.discount = new Discount();
            }
            else
            {
                newCustomer.discount = new Discount(customer.discount);
            }

            newCustomer.saleItems = saleItems;
            newCustomer.transactions = transactions;

            return newCustomer;
        }
    }
}
