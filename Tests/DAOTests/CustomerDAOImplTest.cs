/**
 * Testing methods for CustomerDaoImpl. This test class is
 * not a unit test and is dependent on the Seed file running
 * prior to this test otherwise tests will fails
 * 
 * 
 **/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO.Data;
using System.Collections.Generic;
using Domain.Entities;

namespace Tests
{
    [TestClass]
    public class CustomerDAOImplTest
    {
        CustomerDAOImpl dao;

        [TestInitialize]
        public void init()
        {
            dao = new CustomerDAOImpl();
        }

        [TestMethod]
        public void testGetAllCustomers()
        {
            List<Customer> customers = dao.getAllCustomers();
            printCustomers(customers);
        }

        [TestMethod]
        public void testGetCustomersByFirstName()
        {
            List<Customer> customers = dao.getCustomersByFirstName("Robert");
            printCustomers(customers);
        }

        [TestMethod]
        public void testGetCustomersByLastName()
        {
            List<Customer> customers = dao.getCustomersByLastName("Miller");
            printCustomers(customers);
        }

        [TestMethod]
        public void testGetCustomersByMiddleName()
        {
            List<Customer> customers = dao.getCustomersByMiddleName("Norton");
            printCustomers(customers);
        }

        [TestMethod]
        public void testGetCustomerByPhoneNumber()
        {
            Customer customer = dao.getCustomerByPhoneNumber("555-1234");
            printCustomer(customer);
        }

        [TestMethod]
        public void testGetCustomersByStore()
        {
            List<Customer> customers = dao.getCustomersByStore(1);
            printCustomers(customers);
        }

        [TestMethod]
        public void testGetCustomerByTransactionNumber()
        {
            Customer customer = dao.getCustomerByTransactionNumber("11111");
            printCustomer(customer);
        }

        [TestMethod]
        public void testGetCustomerByAccountNumber()
        {
            //TO-DO Implement Customer account id needed
        }

        [TestMethod]
        public void testGetCustomerById()
        {
            Customer customer = dao.getCustomerByID(1);
            printCustomer(customer);
        }



        private void printCustomers(List<Customer> cust)
        {
            foreach (Customer c in cust)
            {
                Console.WriteLine(c.firstName + " "  + c.middleName + " " + c.lastName);
                Console.WriteLine(c.phoneNumber);
            }
        }

        private void printCustomer(Customer c)
        {
            Console.WriteLine(c.firstName + " " + c.middleName + " " + c.lastName);
            Console.WriteLine(c.phoneNumber);
           
        }
    }
}