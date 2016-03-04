/**
 * Testing methods for SaleItemDaoImpl. This test class is
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
    public class SaleItemDAOTest
    {
        SaleItemDAOImpl dao;

        [TestInitialize]
        public void init()
        {
            dao = new SaleItemDAOImpl();
        }

        [TestMethod]
        public void TestGetSaleItemsByTransaction()
        {
            List<SaleItem> items = dao.getSaleItemsByTransactionNumber("11111");
            foreach (SaleItem item in items)
            {
                Console.WriteLine(item.name);
                Console.WriteLine(item.salePrice);
            }         
        }

        [TestMethod]
        public void TestGetAllSaleItms()
        {
            List<SaleItem> items = dao.getAllSaleItems();
            printItems(items);
        }

        [TestMethod]
        public void TestGetSaleItemsByCustomer()
        {
            Customer cust = new Customer();
            cust.customerId = 1;

            List<SaleItem> items = dao.getSaleItemsByCustomer(cust);
            printItems(items);

            cust.customerId = 2;
            items = dao.getSaleItemsByCustomer(cust);
            printItems(items);

        }

        [TestMethod]
        public void testGetSaleItemsByStore()
        {
            Store store = new Store();
            store.storeId = 1;

            List<SaleItem> items = dao.getSaleItemsByStore(store);
            printItems(items);
        }

        [TestMethod]
        public void testGetSaleItemByBarcode()
        {
            Barcode barcode = new Barcode();
            barcode.number = "1234-4324204324-234";

            SaleItem result = dao.getSaleItemByBarcode(barcode.number);

            Console.WriteLine(result.name);
            Console.WriteLine(result.salePrice);
        }

        [TestMethod]
        public void testGetSaleItemBtPartNo()
        {
            PartNo partNo = new PartNo();
            partNo.number = "4545454454";

            SaleItem result = dao.getSaleItemByPartNo(partNo.number);

            Console.WriteLine(result.name);
            Console.WriteLine(result.salePrice);
        }

        private void printItems(List<SaleItem> items)
        {
            foreach (SaleItem item in items)
            {
                Console.WriteLine(item.name);
                Console.WriteLine(item.salePrice);
            }
        }
    }
}
