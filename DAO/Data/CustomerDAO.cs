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
        Customer getCustomerByPhoneNumber(string number);
        Customer getCustomerByTransactionNumber(string transactionNumber);
        Customer getCustomerByAccountNumber(string number);
        Customer getCustomerByID(int id);

    }
}
