/**
 * Service class to handle all aspectes of customer management
 * --Handles CRUD for a Customer
 */

using System;
using System.Collections.Generic;
using DAO.Data;
using Domain.Entities;


namespace Service.Services
{
    public class CustomerService
    {
        CustomerDAO customerDao;

        StoreDAO storeDao;

        public CustomerService()
        {
            this.customerDao = new CustomerDAOImpl();
            this.storeDao = new StoreDAOImpl();
        }

        public List<Customer> getAllCompanyCustomers()
        {
            return customerDao.getAllCustomers();
        }

        public List<Customer> getStoreCustomers(int storeId)
        {
            return customerDao.getCustomersByStore(storeId);
        }

        public Customer getSimpleCustomerById(int customerId)
        {
            return customerDao.getCustomerByID(customerId, false);
        }

        public Customer getDetailedCustomerByID(int customerId)
        {
            return customerDao.getCustomerByID(customerId, true);
        }

        public List<Customer> getCustomerByFirstName(string firstName)
        {
            return customerDao.getCustomersByFirstName(firstName);
        }

        public List<Customer> getCustomersByLastName(string lastName)
        {
            return customerDao.getCustomersByLastName(lastName);
        }

        public List<Customer> getCustomersByMiddleName(string middleName)
        {
            return customerDao.getCustomersByMiddleName(middleName);
        }

        public Customer getCustomerByPhoneNumber(string phoneNumber)
        {
            return customerDao.getCustomerByPhoneNumber(phoneNumber, true);
        }

        public Customer getCustomerByTransactionNumber(string transactionNumber)
        {
            return customerDao.getCustomerByTransactionNumber(transactionNumber, true);
        }

        public Customer getCustomerByAccountNumber(string accountNumber)
        {
            return customerDao.getCustomerByAccountNumber(accountNumber, true);
        }

        public int addCustomerToStore(Customer customer, int storeId)
        {
            return storeDao.saveCustomerToStore(customer, storeId);
        }

        public int addSaleItemToCustomer(int customerId, SaleItem saleItem)
        {
            Customer customer = customerDao.getCustomerByID(customerId, true);
            customer.saleItems.Add(saleItem);

            return customerDao.saveCustomer(customer);
        }

        public int addTransactionToCustomer(int customerId, Transactions transaction)
        {
            Customer customer = customerDao.getCustomerByID(customerId, true);
            customer.transactions.Add(transaction);

            return customerDao.saveCustomer(customer);
        }

        public int addDiscountToCustomer(int customerId, Discount discount)
        {
            Customer customer = customerDao.getCustomerByID(customerId, true);
            customer.discount = discount;

            return customerDao.saveCustomer(customer);
        }

        public bool storeHasCusomer(int customerId)
        {
            Customer customer = customerDao.getCustomerByID(customerId, true);

            return customerId != 0;
        }


        //////////////////////////////////////////////////////////////////


        public HashSet<Customer> findCustomerByName(string name)
        {
            HashSet<Customer> matches = new HashSet<Customer>();

            foreach (Customer c in getCustomerByFirstName(name))
            {
                matches.Add(c);
            }

            foreach(Customer c in getCustomersByMiddleName(name))
            {
                matches.Add(c);
            }

            foreach (Customer c in getCustomersByLastName(name))
            {
                matches.Add(c);
            }

            return matches;
        }
    }
}
