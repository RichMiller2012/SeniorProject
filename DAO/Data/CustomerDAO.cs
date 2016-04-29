/*
 * Data access methods for Customer
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace DAO.Data
{
    public interface CustomerDAO
    {
        List<Customer> getAllCustomers();
        List<Customer> getCustomersByFirstName(string name);
        List<Customer> getCustomersByLastName(string name); 
        List<Customer> getCustomersByMiddleName(string name);
        List<Customer> getCustomersByStore(int storeId);
        Customer getCustomerByPhoneNumber(string number, bool withDetail);
        Customer getCustomerByTransactionNumber(string transactionNumber, bool withDetail);
        Customer getCustomerByAccountNumber(string number, bool withDetail);
        Customer getCustomerByID(int id, bool withDetail);

        int saveCustomer(Customer customer);
    }
}
