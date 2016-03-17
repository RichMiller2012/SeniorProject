using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using DAO.Data;

namespace Service.Services
{
    public interface CustomerService
    {
        //add a customer
        void addCustomerToStore(Store store, Customer customer);
 
        //view a Customer
        Customer getCustomerByName(string name);

        //Update cusomer sales data
        void updateCustomer(Customer customer);

        //track sales made with a customer
        void updateCustomerSales(Customer customer, SaleItem saleItem);



    }
}
